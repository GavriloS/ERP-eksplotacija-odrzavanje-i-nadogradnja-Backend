﻿namespace TeretanaApi.Model.Equipment
{
    public class EquipmentCreationDto
    {


        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid EquipmentTypeId { get; set; }

    }
}
