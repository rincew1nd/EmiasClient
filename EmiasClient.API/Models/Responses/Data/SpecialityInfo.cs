namespace EmiasClient.API.Models.Responses.Data
{
    public class SpecialityInfo
    {
        /// <summary>
        /// Индентификатор специальности
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Название специальности
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Только для женщин
        /// </summary>
        public bool Famale { get; set; }
        
        /// <summary>
        /// Только для мужчин
        /// </summary>
        public bool Male { get; set; }
        
        /// <summary>
        /// Является терапевтической специальностью
        /// </summary>
        public bool Therapeutic { get; set; }
    }
}