let map;
let infoWindow; // Define infoWindow globally

async function initMap() {
    const position = { lat: 6.9271, lng: 79.8612 };

    // Initialize the map
    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 15,
        center: position,
        mapId: "DEMO_MAP_ID",
    });

    infoWindow = new google.maps.InfoWindow(); // Initialize infoWindow

    const cards = document.querySelectorAll(".card");
    cards.forEach((card, index) => {
        card.addEventListener("click", () => {
            const longitude = parseFloat(card.dataset.longitude);
            const latitude = parseFloat(card.dataset.latitude);
            const coordinates = { lat: latitude, lng: longitude };

            if (map.marker) {
                map.marker.setMap(null);
            }

            // Create a marker
            map.marker = new google.maps.Marker({
                position: coordinates,
                map: map,
                title: "",
            });

            map.setCenter(coordinates);

            // Add mouseover event listener to marker
            google.maps.event.addListener(map.marker, 'mouseover', function () {
                const markerContent = `
                    <div>
                        <h5>${card.querySelector('.card-title').innerText}</h5>
                        <p>${card.querySelector('.card-text').innerText}</p>
                        <p>${card.querySelector('.card-price').innerText}</p>
                    </div>
                `;
                infoWindow.setContent(markerContent);
                infoWindow.open(map, this);
            });

            // Add mouseout event listener to marker
            google.maps.event.addListener(map.marker, 'mouseout', function () {
                infoWindow.close();
            });
        });
    });

    const btnChecks = document.querySelectorAll('.btncheck');
    btnChecks.forEach(button => {
        button.addEventListener('click', function () {
            document.getElementById('studentregform').style.display = 'block';
            document.querySelector('.overlay').style.display = 'block';
        });
    });
}

initMap();



document.addEventListener("DOMContentLoaded", function () {

    var studentregform = document.getElementById('studentregform');
    var overlay = document.querySelector('.overlay');


    var btnChecks = document.querySelectorAll('[id="btncheck"]');
    btnChecks.forEach(function (btncheck) {
        btncheck.addEventListener('click', function (event) {
            event.stopPropagation();
            if (studentregform && overlay) {
                studentregform.style.display = "block";
                overlay.style.display = "block";
            }
        });
    });

    // Close the form and overlay when the close button is clicked
    var closeButton = document.getElementById('closeButton');
    if (closeButton) {
        closeButton.onclick = function () {
            if (studentregform && overlay) {
                studentregform.style.display = "none";
                overlay.style.display = "none";
            }
        }
    }

    // Close the form and overlay when the user clicks outside the form
    overlay.onclick = function (event) {
        if (event.target === overlay) {
            if (studentregform && overlay) {
                studentregform.style.display = "none";
                overlay.style.display = "none";
            }
        }
    }
   
     


});






