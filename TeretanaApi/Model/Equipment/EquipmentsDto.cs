namespace TeretanaApi.Model.Equipment
{
    public class EquipmentsDto
    {
        public List<EquipmentBasicDto> Equipments { get; set; } = new List<EquipmentBasicDto>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
