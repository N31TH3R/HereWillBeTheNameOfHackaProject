ymaps.ready(init);
var myMap;
var layers = "Спорт";
function init() {
    
    if (myMap == null) {
        myMap = new ymaps.Map('map', {
            center: [55.76, 37.64],
            zoom: 10
        }, {
                searchControlProvider: 'yandex#search'
            }),
            objectManager = new ymaps.ObjectManager({
                // Чтобы метки начали кластеризоваться, выставляем опцию.
                clusterize: true,
                geoObjectOpenBalloonOnClick: false,
                clusterOpenBalloonOnClick: false
            });
    }
    

    // Создаём макет содержимого.
    MyIconContentLayout = ymaps.templateLayoutFactory.createClass(
        '<div style="color: #FFFFFF; font-weight: bold; font: arial;">$[properties.iconContent]</div>'
    );

    //Обработка события, возникающего при щелчке
    //левой кнопкой мыши в любой точке карты.
    //При возникновении такого события откроем балун.
    myMap.events.add('click', function (e) {
        
        var coords = e.get('coords');
            
        document.getElementById("newPointForm").style.visibility = "visible";
        document.getElementById("XCoordinate").innerText = coords[0].toPrecision(6);
        document.getElementById("YCoordinate").innerText = coords[1].toPrecision(6);
        
    });

    

    // Обработка события, возникающего при щелчке
    // правой кнопки мыши в любой точке карты.
    // При возникновении такого события покажем всплывающую подсказку
    // в точке щелчка.
    myMap.events.add('contextmenu', function (e) {
        myMap.hint.open(e.get('coords'), 'Кто-то щелкнул правой кнопкой');
    });

    // Скрываем хинт при открытии балуна.
    myMap.events.add('balloonopen', function (e) {
        myMap.hint.close();
    });

    myMap.geoObjects.add(objectManager);

    //$.ajax({
    //    // В файле data.json заданы геометрия, опции и данные меток .
    //    url: "data.json"
    //}).done(function (data) {
    //    //debugger
    //    objectManager.add(data);
    //    });

    //$.getJSON(
    //     "Home/OnGetAsync",
    //     "json", 
    //     function (data, textStatus) {
    //        objectManager.add(data);
    //    }
    //);
    
    $.ajax({
        type: "POST",
        url: "Home/OnGetAsync",
        dataType: "json",
        data: { enabledLayers: layers },
        success: function (data) {
            objectManager.add(data);
        }
    });

    function onObjectEvent(e) {
        var objectId = e.get('objectId');
        if (e.get('type') == 'mouseenter') {
            // Метод setObjectOptions позволяет задавать опции объекта "на лету".
            objectManager.objects.setObjectOptions(objectId, {
                preset: 'islands#yellowCircleIcon'
            });
            document.getElementById("rightPanel").style.visibility = "visible";
            //document.getElementById("hintRightPanel").innerText = objectManager.objects.getById(objectId).properties.hint;
        } else {
            objectManager.objects.setObjectOptions(objectId, {
                preset: 'islands#blueCircleIcon'
            });
            document.getElementById("rightPanel").style.visibility = "hidden";
            //document.getElementById("hintRightPanel").innerText = "";
        }
    }

    function onClusterEvent(e) {
        var objectId = e.get('objectId');
        if (e.get('type') == 'mouseenter') {
            objectManager.clusters.setClusterOptions(objectId, {
                preset: 'islands#yellowClusterIcons'
            });
            document.getElementById("rightPanel").style.visibility = "visible";
        } else {
            objectManager.clusters.setClusterOptions(objectId, {
                preset: 'islands#blueClusterIcons'
            });
            document.getElementById("rightPanel").style.visibility = "hidden";
        }
    }

    objectManager.objects.events.add(['mouseenter', 'mouseleave'], onObjectEvent);
    objectManager.clusters.events.add(['mouseenter', 'mouseleave'], onClusterEvent);
}


