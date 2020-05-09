using System.IO;

namespace BinaryTree_Lab10
{
    public class DataService
    {
        private readonly FileInfo _dataFile;
        public string Expression { get; set; } = "";
        public DataService()
            : this(new FileInfo("Expression.txt"))
        {
        }
        public DataService(FileInfo info)
        {
            _dataFile = info;
            if (_dataFile.Exists)
                using (StreamReader reader = _dataFile.OpenText())
                    Expression = reader.ReadLine();
        }
    }
}
