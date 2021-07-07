namespace EmiasClient.API.Models.Responses.Data
{
    /// <summary>
    /// Описание ресурса
    /// </summary>
    public class ComplexResource
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
        public Room Room { get; set; }
    }
}