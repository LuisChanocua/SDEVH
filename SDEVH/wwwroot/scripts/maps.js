function iniciarMap() {
    var coord =

{
    lat: 18.6507146,lng: -100.9001183
}

;
var map = new google.maps.Map(document.getElementById('map'),{
      zoom: 10,
      center: coord
    });
var marker = new google.maps.Marker({
      position: coord,
      map: map
    });
}
