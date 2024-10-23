using System;
using System.Collections.Generic;

namespace tourismApp.Models.Requests
{
    public class ItineraryRequest
    {
        public Guid UserId { get; set; }  // ID del usuario que está creando el itinerario
        public List<Guid> SelectedAttractions { get; set; }  // Lista de atracciones seleccionadas
    }
}
