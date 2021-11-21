using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Common.Config
{
    public class BasicConfiguration
    {

        private Configuration _configuration;

        public BasicConfiguration(string configFilePath)
        {
            var fileMap = new ConfigurationFileMap(configFilePath);
            _configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        }

        public static string MediaCenterGroupCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MediaCenterGroupCode"];
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        public static string DefaultUserName()
        {
            try
            {
                return ConfigurationManager.AppSettings["DefaultUserName"];
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        public static string DefaultPassword()
        {
            try
            {
                return ConfigurationManager.AppSettings["DefaultPassword"];
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }


        public static string ImagesStorageUrl()
        {
            try
            {
                return ConfigurationManager.AppSettings["ImagesStorageUrl"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ImagesStorageUrlPHYS()
        {
            try
            {
                return ConfigurationManager.AppSettings["ImagesStoragePath"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string VideosStorageUrl()
        {
            try
            {
                return ConfigurationManager.AppSettings["VideosStorageUrl"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string VideosStorageUrlPHYS()
        {
            try
            {
                return ConfigurationManager.AppSettings["VideosStoragePath"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string AudiosStorageUrl()
        {
            try
            {
                return ConfigurationManager.AppSettings["AudiosStorageUrl"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string AudiosStorageUrlPHYS()
        {
            try
            {
                return ConfigurationManager.AppSettings["AudiosStoragePath"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string FilesStorageUrlPHYS()
        {
            try
            {
                return ConfigurationManager.AppSettings["FilesStoragePath"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string FilesStorageUrl()
        {
            try
            {
                return ConfigurationManager.AppSettings["FilesStorageUrl"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string BannersStorageUrl()
        {
            try
            {
                return ConfigurationManager.AppSettings["BannersStorageUrl"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string BannersStorageUrlPHYS()
        {
            try
            {
                return ConfigurationManager.AppSettings["BannersStoragePath"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int ServerGmtHours()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["ServerGmtHours"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ServerGmtMinutes()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["ServerGmtMinutes"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ClientGmtHours()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["ClientGmtHours"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ClientGmtMinutes()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["ClientGmtMinutes"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string ProfileImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ProfileImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ProfileTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ProfileTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ProfileBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ProfileBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        //

        public static string GroupImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["GroupImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ContentTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ContentTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ContentBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ContentBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string TagTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["TagImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string TagBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["TagBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static string CompetitionTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["CompetitionTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string CompetitionBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["CompetitionBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string SeasonTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["SeasonTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string SeasonBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["SeasonBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string StadiumTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["StadiumTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string StadiumBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["StadiumBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string MatchGroupTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MatchGroupTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string MatchGroupBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MatchGroupBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string RoundTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["RoundTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string RoundBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["RoundBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string MatchTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MatchTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string MatchBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MatchBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ClubTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ClubTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ClubBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ClubBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string CompanyTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["CompanyTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string CompanyBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["CompanyBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ServiceTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ServiceTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ServiceBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["ServiceBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string EventTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["EventTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string EventBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["EventBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string EventIconImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["EventIconImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string PropertyTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["PropertyTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string PropertyBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["PropertyBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string UserTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["UserTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string UserBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["UserBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string PageTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["PageTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string PageBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["PageBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string MediaTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MediaTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string MediaBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MediaBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string LocationTitleImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["LocationTitleImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string LocationBodyImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["LocationBodyImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        //

        public static string MediaImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MediaImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string MediaImageIconSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MediaImageIconSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string MediaListImageSizeCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MediaListImageSizeCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int PlayerHeight()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["PlayerHeight"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int PlayerWidth()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["PlayerWidth"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int MediaCenterPageSize()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["MediaCenterPageSize"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int CommentPageSize()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["CommentPageSize"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static string WebsiteDomain()
        {
            try
            {
                return ConfigurationManager.AppSettings["WebsiteDomain"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string MainExperienceCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["MainExperienceCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }




        //
        public static string WorkingAreaGroupCode()
        {
            try
            {
                return ConfigurationManager.AppSettings["WorkingAreaGroupCode"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string InnovatorWorkingAreaGroup()
        {
            try
            {
                return ConfigurationManager.AppSettings["InnovatorWorkingAreaGroup"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string InvestorWorkingAreaGroup()
        {
            try
            {
                return ConfigurationManager.AppSettings["InvestorWorkingAreaGroup"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string MentorWorkingAreaGroup()
        {
            try
            {
                return ConfigurationManager.AppSettings["MentorWorkingAreaGroup"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string CompanyAgentWorkingAreaGroup()
        {
            try
            {
                return ConfigurationManager.AppSettings["CompanyAgentWorkingAreaGroup"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ExpertWorkingAreaGroup()
        {
            try
            {
                return ConfigurationManager.AppSettings["ExpertWorkingAreaGroup"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string FounderWorkingAreaGroup()
        {
            try
            {
                return ConfigurationManager.AppSettings["FounderWorkingAreaGroup"];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int RssPageCount()
        {
            try
            {
                return int.Parse(ConfigurationManager.AppSettings["RssPageCount"]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static string CsvDelimiter()
        {
            try
            {
                return ConfigurationManager.AppSettings["CsvDelimiter"];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string MaxDays()
        {
            try
            {
                return ConfigurationManager.AppSettings["maxDays"];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
