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
            console.log(response)
        }).catch(error => {
            console.log(error)
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
            console.log(response)
        }).catch(error => {
            console.log(error)
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
        console.log(response)
        console.log(response.data.user)
        console.log(response.data.person)
        console.log(response.data.fretista)
    })
    .catch(error => {
    console.log(error)
    })
 }
    