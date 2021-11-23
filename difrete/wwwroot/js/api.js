// 1 consulta de fretistas ativos
// 2 endpoint para solicitar um fretista
// 3 endpoint para consultar solicitações pendentes
// 4 endopint para excluir uma solicitação
// 5 endpoint para consultar solicitações finalizadas

axios.interceptors.request.use(function (config) {
    if (!isJwtExpired()) {
        config.headers.Bearer = "Bearer " + localStorage.getItem('jwt')
    }
    return config;
}, function (error) {
    return Promise.reject(error);
});

axios.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    if (error.response.status === 401) {
        alert('Sessão expirada!')
        window.location.href = '/Home/Index'
    } else {
        if (!!error?.response?.data?.message) {
            alert(error.response.data.message)
        }
    }
    return Promise.reject(error);
});

function formContratante() {
    event.preventDefault();

    //Recuperando os inputs do form de Contratante
    let email = document.getElementById('inputEmail').value;
    let senha = document.getElementById('inputPassword').value;
    let nome = document.getElementById('inputName').value;
    let cpf = document.getElementById('inputCpf').value;
    let celular = document.getElementById('inputPhone').value;
    //let radio = document.getElementById('gridCheck').value;

    //validar radio
    //if (radio == false) {
    //    alert('Aceite obrigatório para continuar!');
    //}

    if (nome == "") {
    alert("Campo obrigatório. Preencha o nome!");
    nome.focus();
    }

    else if (email == "" || email.indexOf('@') == -1 || email.indexOf('.') == -1) {
        alert("Campo obrigatório. E-mail inválido");
        email.focus();
    }
    else if (senha == "") {
        alert("Campo obrigatório. Senha inválida");
        senha.focus();
    }

    else if (cpf == "") {
        alert("Campo obrigatório. CPF inválido");
        cpf.focus();
    }
    else if (celular == "") {

        alert("Campo obrigatório. Preencha o celular!");
        celular.focus();
    }
    else {

        //Realizando o POST
        axios({
            method: 'post',
            url: 'https://localhost:44366/api/users',
            data: {
                email: email,
                password: senha,
                person: {
                    name: nome,
                    cpf: cpf,
                    celular: celular
                },
            }
        }).then(response => {
            guardarJwt(response.data.token)
            window.location.href = "/MainContratante"
        })
    }
}

function formFretista() {
    event.preventDefault();

    //Recuperando os inputs do form de Fretista
    let rntrc = document.getElementById('inputRntrc').value;
    let razaoSocial = document.getElementById('inputRazaoSocial').value;
    let cnpj = document.getElementById('inputCnpj').value;
    let nome = document.getElementById('inputName').value;
    let email = document.getElementById('inputEmail').value;
    let senha = document.getElementById('inputPassword').value;
    let cpf = document.getElementById('inputCpf').value;
    let celular = document.getElementById('inputPhone').value;

    if (rntrc == "") {
        alert("Campo obrigatório. Preencha o RNTRC!");
        rntrc.focus();
    }
    else if (razaoSocial == "") {
        alert("Campo obrigatório. Preencha a Razão Social!");
        razaoSocial.focus();
    }
    else if (cnpj == "") {
        alert("Campo obrigatório. Preencha o CNPJ!");
        cnpj.focus();
    }
    else if (nome == "") {
        alert("Campo obrigatório. Preencha o nome!");
        nome.focus();
    }
    else if (email == "" || email.indexOf('@') == -1 || email.indexOf('.') == -1) {
        alert("Campo obrigatório. E-mail inválido");
        email.focus();
    }
    else if (senha == "") {
        alert("Campo obrigatório. Senha inválida");
        senha.focus();
    }
    else if (cpf == "") {
        alert("Campo obrigatório. CPF inválido");
        cpf.focus();
    }
    else if (celular == "") {

        alert("Campo obrigatório. Preencha o celular!");
        celular.focus();
    }
    else {

        //Realizando o POST
        axios({
            method: 'post',
            url: 'https://localhost:44366/api/users',
            data: {
                email: email,
                password: senha,
                person: {
                    name: nome,
                    cpf: cpf,
                    celular: celular
                },
                fretista: {
                    razaoSocial: razaoSocial,
                    cnpj: cnpj,
                    rntrc: rntrc
                }
            }
        }).then(response => {
            guardarJwt(response.data.token)
            window.location.href = "/MainFretista"
        })
    }
}

//Realizando Get para entrar no sistema
function Login() {
    event.preventDefault();

    let email = document.getElementById('floatingInput').value;
    let senha = document.getElementById('floatingPassword').value;

    axios({
        method: 'post',
        url: 'https://localhost:44366/api/users/authenticate',
        data: {
            email: email,
            password: senha
        }
    })
        .then(response => {
            guardarJwt(response.data.token)
            if (isFretista()) {
                window.location = '/MainFretista'
            } else if (isContratante()) {
                window.location = '/MainContratante'
            }
    })
 }
    