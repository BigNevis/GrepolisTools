$(function () {
    $('#show-register').on('click', function (e) {
        e.preventDefault();
        $('#register-form').show();
        $(this).parent().hide();
    });

    $('#show-login').on('click', function (e) {
        e.preventDefault();
        $('#register-form').hide();
        $(this).parent().parent().find('.form').first().show();
    });

    $('#login-form').on('submit', function (e) {
        e.preventDefault();
        var username = $('#username').val();
        var password = $('#password').val();
        $.ajax({
            url: 'https://localhost:7028/api/User/login',
            method: 'POST',
            data: JSON.stringify({
                username: username,
                password: password
            }),
            contentType: 'application/json',
            success: function (response) {
                // Redirige al usuario a dashboard.html
                window.location.href = 'dashboard.html';
            },
            error: function () {
                alert('Failed to log in.');
            }
        });
    });

    $('#register-form').on('submit', function (e) {
        e.preventDefault();
        var username = $('#new_username').val();
        var name = $('#name').val();
        var password = $('#new_password').val();
        var email = $('#email').val();
        var RoleId = 1;
        var AllianceId = 1;
        var StateId = 8;
        $.ajax({
            url: 'https://localhost:7028/api/User',
            method: 'POST',
            data: JSON.stringify({
                username: username,
                name: name,
                password: password,
                email: email,
                "RoleId": RoleId,
                "AllianceId": AllianceId,
                "StateId": StateId
            }),
            contentType: 'application/json',
            success: function (response) {
                alert('Registered successfully!');
                $('#register-form').hide();
                $('#login-form').show();
            },
            error: function () {
                alert('Failed to register.');
            }
        });
    });
});
