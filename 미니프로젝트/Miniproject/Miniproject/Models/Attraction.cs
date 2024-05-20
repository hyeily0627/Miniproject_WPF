using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniproject.Models
{
    public class Attraction
    {
        
        public string MAIN_TITLE { get; set; } // 콘텐츠명
        public string GUGUN_NM { get; set; } // 구,군 이름
        public double LAT { get; set; } // 위도
        public double LNG { get; set; } // 경도
        public string PLACE { get; set; } // 여행지
        public string TITLE { get; set; } // 제목
        public string SUBTITLE { get; set; } // 부제목
        public string ADDR1 { get; set; } // 주소
        public string CNTCT_TEL { get; set; } // 연락처
        public string HOMEPAGE_URL { get; set; } // 홈페이지 
        public string TRFC_INFO { get; set; } // 교통정보
        public string USAGE_AMOUNT { get; set; } // 이용요금
        public string MIDDLE_SIZE_RM1 { get; set; } // 편의시설
        public string ITEMCNTNTS { get; set; } // 상세내용


        public static readonly string INSERT_QUERY = @"INSERT INTO [dbo].[Busan]
                                                       ([MAIN_TITLE]
                                                       ,[GUGUN_NM]
                                                       ,[LAT]
                                                       ,[LNG]
                                                       ,[PLACE]
                                                       ,[TITLE]
                                                       ,[SUBTITLE]
                                                       ,[ADDR1]
                                                       ,[CNTCT_TEL]
                                                       ,[HOMEPAGE_URL]
                                                       ,[TRFC_INFO]
                                                       ,[USAGE_AMOUNT]
                                                       ,[MIDDLE_SIZE_RM1]
                                                       ,[ITEMCNTNTS])
                                                 VALUES
                                                       (@MAIN_TITLE
                                                       ,@GUGUN_NM
                                                       ,@LAT
                                                       ,@LNG
                                                       ,@PLACE
                                                       ,@TITLE
                                                       ,@SUBTITLE
                                                       ,@ADDR1
                                                       ,@CNTCT_TEL
                                                       ,@HOMEPAGE_URL
                                                       ,@TRFC_INFO
                                                       ,@USAGE_AMOUNT
                                                       ,@MIDDLE_SIZE_RM1
                                                       ,@ITEMCNTNTS";

        public static readonly string SELECT_QUERY = @"SELECT [MAIN_TITLE]
                                                      ,[GUGUN_NM]
                                                      ,[LAT]
                                                      ,[LNG]
                                                      ,[PLACE]
                                                      ,[TITLE]
                                                      ,[SUBTITLE]
                                                      ,[ADDR1]
                                                      ,[CNTCT_TEL]
                                                      ,[HOMEPAGE_URL]
                                                      ,[TRFC_INFO]
                                                      ,[USAGE_AMOUNT]
                                                      ,[MIDDLE_SIZE_RM1]
                                                      ,[ITEMCNTNTS]
                                                  FROM [dbo].[Busan]";

        //public static readonly string GETDATE_QUERY = @"";
    }
}

