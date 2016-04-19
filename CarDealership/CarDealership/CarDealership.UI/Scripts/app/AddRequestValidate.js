$(document).ready(function () {
    $('#AddRequest').validate({
        rules: {
            FirstName: {
                required: true
            },
            LastName: {
                required: true
            },
            PhoneNumber: {
                required: true
            },
            EmailAddress: {
                required: true,
                email: true
            },
            PreferedContactMethod: {
                required: true
            }
        },
        messages: {
            FirstName: "Please enter your First Name",
            LastName: "Please enter your Last Name",
            PhoneNumber: "Please enter your Phone",
            EmailAddress: {
                required: "Please enter your email",
                email: "Please enter a valid email"
            },
            PreferedContactMethod: "Please choose an option"
        }
    });
});