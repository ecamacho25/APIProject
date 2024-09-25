using System;
namespace APIProject.Resources.Utils
{

    public static class Utils
	{

        private const string _testDataFolderPath = "Resources/TestData";


        public static string ReadJsonFileFromTestdata (string filename)
		{
            var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../"));
            var jsonFilePath = Path.Combine(projectRoot, _testDataFolderPath, filename);
            var expectedResponseContent = File.ReadAllText(jsonFilePath);
			return expectedResponseContent;
        }

	}
}

