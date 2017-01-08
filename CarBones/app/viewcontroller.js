
(function ($, Backbone, dataservice) {

    // Get templates
    var content = $("#content");
    var carTemplateSource = $("#car-template").html();
    var optionTemplateSource = $("#option-template").html();

    var getCars = function() {
        content.empty();
        dataservice.getCars()
            .then(gotCars);

        function gotCars(cars) {
            cars.forEach(// show cars
                function(car) {
                    var view = new CarView({ model: car });
                    content.append(view.render().el);
                });
            enableSave();
        } 
    };

    var enableSave = function() {
        var saveElements = $(".save");
        saveElements.removeClass("hidden");
        // only add the click handler once
        if (enableSave.initialized) { return; }
        saveElements.click(function() {
            dataservice.saveChanges();
        });
        enableSave.initialized = true;
    };

    getCars(); 
    
})(jQuery, Backbone, app.dataservice);