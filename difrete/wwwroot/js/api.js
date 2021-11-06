function formContratante() {
    event.preventDefault();

    //Recuperando os inputs do form de Fretista
    let email = document.getElementById('inputEmail').value;
    let senha = document.getElementById('inputPassWord').value;
    let nome = document.getElementById('inputName').value;
    let cpf = document.getElementById('inputCpf').value;
    let celular = document.getElementById('inputPhone').value;

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
            loginType: 0
        }
    })
        .then(response => {
            console.log(response)
        })
        .catch(error => {
            console.log(error)
        })
}

//Realizando Get para entrar no sistema //// FALTA FINALIZAR
function Login() {
    let email = document.getElementById('floatingInput').value;
    let senha = document.getElementById('floatingPassword').value;

    axios({
        method: 'get',
        url: 'https://localhost:44366/api/users',
        data: {
            email: email,
            password: senha,
        }
    })
    .then(response => {
        console.log(response)
    })
    .catch(error => {
        console.log(error)
    })

}

