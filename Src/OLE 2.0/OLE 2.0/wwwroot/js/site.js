﻿ymaps.ready(init);
function init() {
    var myMap = new ymaps.Map('map', {
        center: [55.76, 37.64],
        zoom: 10
    }, {
            searchControlProvider: 'yandex#search'
        }),
        objectManager = new ymaps.ObjectManager();

    // Создаём макет содержимого.
    MyIconContentLayout = ymaps.templateLayoutFactory.createClass(
        '<div style="color: #FFFFFF; font-weight: bold; font: arial;">$[properties.iconContent]</div>'
    );

    //Обработка события, возникающего при щелчке
    //левой кнопкой мыши в любой точке карты.
    //При возникновении такого события откроем балун.
    myMap.events.add('click', function (e) {
        if (!myMap.balloon.isOpen()) {
            var coords = e.get('coords');
            myMap.balloon.open(coords, {
                contentHeader: 'Событие!',
                contentBody: '<p>Кто-то щелкнул по карте.</p>' +
                '<p>Координаты щелчка: ' + [
                    coords[0].toPrecision(6),
                    coords[1].toPrecision(6)
                ].join(', ') + '</p>',
                contentFooter: '<sup>Щелкните еще раз</sup>'
            });
            myPlacemarkWithContent.coords = coords;
            myMap.geoObjects
                .add(myPlacemarkWithContent);
        }
        else {
            myMap.balloon.close();
        }
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

    $.ajax({
        // В файле data.json заданы геометрия, опции и данные меток .
        url: "data.json"
    }).done(function (data) {
        //debugger
        objectManager.add(data);
    });
}

