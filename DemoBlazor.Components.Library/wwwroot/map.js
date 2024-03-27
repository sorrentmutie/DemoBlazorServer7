import 'https://unpkg.com/leaflet@1.9.4/dist/leaflet.js';
export function showMap(mapSettings)
{
    console.log(mapSettings);
    var map = L.map(mapSettings.id).setView([mapSettings.latitudine, mapSettings.longitudine], mapSettings.zoom);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);
    var marker = L.marker([mapSettings.latitudine, mapSettings.longitudine]).addTo(map);
    var circle = L.circle([51.508, -0.11], {
        color: 'green',
        fillColor: 'green',
        fillOpacity: 0.5,
        radius: 100
    }).addTo(map);
}