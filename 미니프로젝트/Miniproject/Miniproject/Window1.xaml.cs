using Microsoft.VisualBasic.Devices;
using Miniproject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Miniproject
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        private string searchKeyword;
        public Window1(string keyword)
        {
            InitializeComponent();
            searchKeyword = keyword;
        }

        private async void Busansearch_Loaded(object sender, RoutedEventArgs e)
        {
            
             string openApiUri = "https://apis.data.go.kr/6260000/AttractionService/getAttractionKr?serviceKey=ZWzY%2BaXaAxa6uaINctI3EjRA4kcyYOoPzwebpFlGhuvk3PQCHkyn6CLNtMHN7NyVoMUFEVub1%2BCzXExqMR3YoQ%3D%3D&pageNo=1&numOfRows=1000&resultType=json";
             string result = string.Empty;

             WebRequest req = null;  
             WebResponse res = null; 
             StreamReader reader = null;

                try
                {
                    req = WebRequest.Create(openApiUri);
                    res = await req.GetResponseAsync();
                    reader = new StreamReader(res.GetResponseStream());
                    result = reader.ReadToEnd();

                    //await this.ShowMessageAsync("결과", result);
                    Debug.WriteLine(result);
                }
                catch (Exception ex)
            {
                MessageBox.Show("오류", $"OpenAPI 조회오류 {ex.Message}");

            }

            var jsonResult = JObject.Parse(result);
                var header = jsonResult["getAttractionKr"]["header"];
                var code = Convert.ToInt32(header["code"]);

                    var data = jsonResult["getAttractionKr"]["item"];
                    var jsonArray = data as JArray; // json자체에서 []안에 들어간 배열데이터만 JArray 변환가능

                    var attraction = new List<Attraction>();
                    foreach (var item in jsonArray)
                    {
                        attraction.Add(new Attraction()
                        {
                        
                            MAIN_TITLE = Convert.ToString(item["MAIN_TITLE"]),
                            GUGUN_NM = Convert.ToString(item["GUGUN_NM"]),
                            LAT = Convert.ToDouble(item["LAT"]),
                            LNG = Convert.ToDouble(item["LNG"]),
                            PLACE = Convert.ToString(item["PLACE"]),
                            TITLE = Convert.ToString(item["TITLE"]),
                            SUBTITLE = Convert.ToString(item["SUBTITLE"]),
                            ADDR1 = Convert.ToString(item["ADDR1"]),
                            CNTCT_TEL = Convert.ToString(item["CNTCT_TEL"]),
                            HOMEPAGE_URL = Convert.ToString(item["HOMEPAGE_URL"]),
                            TRFC_INFO = Convert.ToString(item["TRFC_INFO"]),
                            USAGE_AMOUNT = Convert.ToString(item["USAGE_AMOUNT"]),
                            MIDDLE_SIZE_RM1 = Convert.ToString(item["MIDDLE_SIZE_RM1"]),
                            ITEMCNTNTS = Convert.ToString(item["ITEMCNTNTS"]),
                            MAIN_IMG_NORMAL = Convert.ToString(item["MAIN_IMG_NORMAL"])
                        });
                    }
            var filteredAttraction = attraction.Where(a => a.MAIN_TITLE.Contains(searchKeyword)).ToList();

            // 데이터 컨텍스트에 필터링된 리스트 설정
            this.DataContext = filteredAttraction;
            StsResult.Content = $"OpenAPI {filteredAttraction.Count}건 조회 완료!";
            if(filteredAttraction.Count == 0)
            {
                MessageBox.Show("검색목록이 없습니다");
            }


        }

        private void GrdResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = e.AddedItems[0] as Attraction;
                if (item != null)
                {
                    var poster_url = item.MAIN_IMG_NORMAL;
                    if (string.IsNullOrEmpty(poster_url))
                    {
                        ImgPoster.Source = new BitmapImage(new Uri("/No_Picture.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        ImgPoster.Source = new BitmapImage(new Uri(poster_url, UriKind.Absolute));
                    }

                    // 포스터 설명 텍스트 업데이트
                    poster_name.Text = item.ITEMCNTNTS;
                    poster.Text = "지역 설명";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }


        }
    }
}
