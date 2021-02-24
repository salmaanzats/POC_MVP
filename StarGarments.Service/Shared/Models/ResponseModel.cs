namespace StarGarments.Service.Shared.Models
{
    public class ReponseModel<TModel> where TModel : class
    {
        public int TotalRecordCount { get; set; }
        public TModel data { get; set; }

        public bool success { get; set; }
        public string message { get; set; }

        public string validationErrors { get; set; }
    }
}
