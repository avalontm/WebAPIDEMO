namespace WebAPIDEMO.Models
{
    public class ResponseModel
    {
        public bool status { set; get; }
        public string message { set; get; }
        public List<object> data { set; get; }

        public ResponseModel()
        {
            data = new List<object>();
        }
    }
}
