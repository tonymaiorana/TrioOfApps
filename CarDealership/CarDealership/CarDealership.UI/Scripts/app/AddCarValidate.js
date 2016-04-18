$(document).ready(function () {
    $('#Vehicle').validate({
        rules: {
            Name: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            Phone: {
                required: true
            },
            FavoriteGame: {
                required: true
            },
            WillAttend: {
                required: true
            }
        },
        messages: {
            Name: "Enter your name",
            Email: {
                required: "Enter your email address",
                email: "Please enter a valid email"
            },
            Phone: "Enter your Phone",
            FavoriteGame: "Enter your Favorite Game",
            WillAttend: "Choose whether you will attend"
        }
    });
});