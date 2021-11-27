function getFretista() {
    axios({
        method: 'get',
        url: 'https://localhost:44366/api/fretista/logado',
    }).then(response => {
        const container = $('#cardFretista');

        const card = getCard(response.data);

        if (response.data.isAtivo) {
            $("#radioOnline").prop("checked", true);
        } else {
            $("#radioOffline").prop("checked", true);
        }

        container.html(card);
    })
}

function getCard(fretista) {
    return `
        <div class="card" style="width: 22rem; border: solid 2px; border-color: blue;">
            <div class="card-body">
                <center><h6 class="card-title"><strong>${fretista.razaoSocial}</strong></h6></center>
                <br />
                <p class="card-title"><strong>CNPJ:</strong> ${fretista.cnpj}</p>
                <p class="card-title"><strong>Nome:</strong> ${fretista.nome}</p>
                <p class="card-title"><strong>E-mail:</strong> ${fretista.email}</p>
                <p class="card-title"><strong>Celular:</strong> ${fretista.celular}</p>
                <br />
            </div>
        </div>
    `;
}

function ativar() {
    axios({
        method: 'patch',
        url: 'https://localhost:44366/api/fretista/ativar',
    }).then(response => {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Serviço ativo!',
            text: 'Você está disponível.',
            showConfirmButton: false,
            timer: 3500
        })
    })
}

function inativar() {
    axios({
        method: 'patch',
        url: 'https://localhost:44366/api/fretista/inativar',
    }).then(response => {
        Swal.fire({
            position: 'top-end',
            icon: 'warning',
            title: 'Serviço inativo!',
            text: 'Você está indisponível.',
            showConfirmButton: false,
            timer: 3500
        })
    })
}

getFretista();
