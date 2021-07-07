namespace EmiasClient.API.Models.Responses.Data
{
    /// <summary>
    /// Тип приёма
    /// </summary>
    public class ReceptionType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// ???
        /// </summary>
        public string Primary { get; set; }
        
        /// <summary>
        /// Надом???
        /// </summary>
        public string Home { get; set; }
    }
}