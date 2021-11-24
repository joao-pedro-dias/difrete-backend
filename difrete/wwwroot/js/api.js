// 1 consulta de fretistas ativos
// 2 endpoint para solicitar um fretista
// 3 endpoint para consultar solicitações pendentes
// 4 endopint para excluir uma solicitação
// 5 endpoint para consultar solicitações finalizadas


/*REQUEST*/
axios.interceptors.request.use(function (config) {
    if (!isJwtExpired()) {
        config.headers.Bearer = "Bearer " + localStorage.getItem('jwt')
    }
    return config;
}, function (error) {
    return Promise.reject(error);
});

/*RESPONSE*/
axios.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    if (error.response.status === 401) {
        alert('Sessão expirada!')
        window.location.href = '/Home/Index'
    } else {
        if (error?.response?.data?.message) {
            if (error.response.data.message === "E-mail já cadastrado!") {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'E-mail já cadastrado!',
                })
            } else if (error.response.data.message === "E-mail/ Senha inválidos") {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'E-mail/ Senha inválidos',
                })
            } else if (error.response.data.message === "Preencha E-mail/ Senha") {
                Swal.fire({
                    icon: 'warning',
                    text: 'Preencha E-mail/ Senha',
                })
            }
        }
        /*alert(error.response.data.message)*/
        
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
        alert("Campo obrigatório. Preencha o campo [  Nome completo  ] !");
        document.getElementById('inputName').focus();
    }

    else if (email == "" || email.indexOf('@') == -1 || email.indexOf('.') == -1) {
        alert("Campo obrigatório. Preencha o campo [  E-mail  ] corretamente!");
        document.getElementById('inputEmail').focus();
    }
    else if (senha == "") {
        alert("Campo obrigatório. Preencha o campo [  Senha  ] !");
        document.getElementById('inputPassword').focus();
    }

    else if (cpf == "" || cpf.length <= 13) {
        alert("Campo obrigatório. Preencha o [  CPF  ] corretamente!");
        document.getElementById('inputCpf').focus();
    }
    else if (celular == "" || celular.length <= 14) {

        alert("Campo obrigatório. Preencha o [  Celular  ] corretamente!");
        document.getElementById('inputPhone').focus();
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
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })

            Toast.fire({
                icon: 'success',
                title: 'Contratante cadastrado com sucesso!'
            })

            setTimeout(function () {
                guardarJwt(response.data.token)
                window.location.href = "/MainContratante"
            }, 3000)
            
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
        alert("Campo obrigatório. Preencha o campo [  RNTRC  ] !");
        document.getElementById('inputRntrc').focus();
    }
    else if (razaoSocial == "") {
        alert("Campo obrigatório. Preencha o campo [  Razão Social  ] !");
        document.getElementById('inputRazaoSocial').focus();
    }
    else if (cnpj == "" || cnpj.length <= 17 ) {
        alert("Campo obrigatório. Preencha o campo [  CNPJ  ] corretamente!");
        document.getElementById('inputCnpj').focus();
    }
    else if (nome == "") {
        alert("Campo obrigatório. Preencha o campo [  Nome completo  ] !");
        document.getElementById('inputName').focus();
    }
    else if (email == "" || email.indexOf('@') == -1 || email.indexOf('.') == -1) {
        alert("Campo obrigatório. Preencha o campo [  E-mail  ] corretamente!");
        document.getElementById('inputEmail').focus();
    }
    else if (senha == "") {
        alert("Campo obrigatório. Preencha o campo [  Senha  ] !");
        document.getElementById('inputPassword').focus();
    }
    else if (cpf == "" || cpf.length <= 13) {
        alert("Campo obrigatório. Preencha o [  CPF  ] corretamente!");
        document.getElementById('inputCpf').focus();
    }
    else if (celular == "" || celular.length <= 14) {

        alert("Campo obrigatório. Preencha o [  Celular  ] corretamente!");
        document.getElementById('inputPhone').focus();
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
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })

            Toast.fire({
                icon: 'success',
                title: 'Fretista cadastrado com sucesso!'
            })

            setTimeout(function () {
                guardarJwt(response.data.token)
                window.location.href = "/MainFretista"
            }, 3000)
            
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
            
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })

            Toast.fire({
                icon: 'success',
                title: 'Realizado autenticação de usuário!'
            })

            setTimeout(function () {
                guardarJwt(response.data.token)
                if (isFretista()) {
                    window.location = '/MainFretista'
                } else if (isContratante()) {
                    window.location = '/MainContratante'
                }
            }, 3000)
        })
 }
    