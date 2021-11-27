(function ($) {
	"use strict";

	var fullHeight = function () {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function () {
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

    setTimeout(function () {
        $('#user-email').text(getJwt().email)
    })

})(jQuery);

function post() {
    console.log("Iniciando...");
    $.ajax({
        type: "GET",
        url: '/api/users',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {
        console.log(data.result);
    })
}

function mascaraCpf(i) {
    var v = i.value;

    if (isNaN(v[v.length - 1])) { // impede entrar outro caractere que não seja número
        i.value = v.substring(0, v.length - 1);
        return;
    }

    i.setAttribute("maxlength", "14");
    if (v.length == 3 || v.length == 7) i.value += ".";
    if (v.length == 11) i.value += "-";
}

function mascaraCnpj(i) {

    var v = i.value;

    if (isNaN(v[v.length - 1])) { // impede entrar outro caractere que não seja número
        i.value = v.substring(0, v.length - 1);
        return;
    }

    i.setAttribute("maxlength", "18");
    if (v.length == 2) i.value += ".";
    if (v.length == 6) i.value += ".";
    if (v.length == 10) i.value += "/";
    if (v.length == 15) i.value += "-";
}

function mask(o, f) {
    setTimeout(function () {
        var v = mphone(o.value);
        if (v != o.value) {
            o.value = v;
        }
    }, 1);
}

function mphone(v) {
    var r = v.replace(/\D/g, "");
    r = r.replace(/^0/, "");
    if (r.length > 10) {
        r = r.replace(/^(\d\d)(\d{5})(\d{4}).*/, "($1) $2-$3");
    } else if (r.length > 5) {
        r = r.replace(/^(\d\d)(\d{4})(\d{0,4}).*/, "($1) $2-$3");
    } else if (r.length > 2) {
        r = r.replace(/^(\d\d)(\d{0,5})/, "($1) $2");
    } else {
        r = r.replace(/^(\d*)/, "($1");
    }
    return r;
}

/*MOSTRAR CARD QUANDO ESTIVER online E OCULTAR CARD QUANDO ESTIVER offline*/
//function checkInputFretista() {
//    $('#flexSwitchCheckChecked').on('click', function (e) {
//        var online = $('#radioOnline').is(':checked');
//        var offline = $('#radioOffline').is(':checked');

//        do {
//            var cardOn = $('#container').html("<ul class='grid cards'><li><h2>Serviço</h2><h5>Razão social: #RazaoSocial</h5><p>CNPJ: #CNPJ</p><p>Nome: #NomeFretista</p><p>Celular: #CelularFretista</p><p>E-mail: #EmailFretista</p></li></ul>");
//            cardOn.show();

//        } while (online == true)

//        do {
//            var cardOff = $('#container').html("<ul class='grid cards'><li><h2>Serviço</h2><h5>Razão social: #RazaoSocial</h5><p>CNPJ: #CNPJ</p><p>Nome: #NomeFretista</p><p>Celular: #CelularFretista</p><p>E-mail: #EmailFretista</p></li></ul>");
//            cardOff.hide();
//        } while(offline == true)
//    });
//}
