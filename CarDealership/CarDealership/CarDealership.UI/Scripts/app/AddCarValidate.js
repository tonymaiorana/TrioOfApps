$(document).ready(function () {
    $('#AddCar').validate({
        rules: {
            Make: {
                required: true
            },
            Model: {
                required: true,
            },
            Phone: {
                required: true
            },
            Year: {
                required: true
            },
            AdTitle: {
                required: true
            },
            IsAvailable: {
                required: true
            },
            IsNew: {
                required: true
            }
        },
        messages: {
            Make: "Please enter the Make",
            Model: "Please enter the Model",
            Year: "Please enter the Year",
            AdTitle: "Please enter an Ad Title",
            IsAvailable: "Please choose an option",
            IsNew: "Please choose the condition"
        }
    });
});