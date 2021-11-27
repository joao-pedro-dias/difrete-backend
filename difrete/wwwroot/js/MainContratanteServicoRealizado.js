function getSolicitacoesEncerradas() {
    axios({
        method: 'get',
        url: 'https://localhost:44366/api/solicitacao/encerradas',
    }).then(response => {

        const container = $('#container');

        const cards = response.data.map(solicitacao => getCard(solicitacao))

        container.html(cards);
    })
}

function getCard(solicitacao) {
    //TODO:  ajustar margin
    return `
        <div class="card" style="width: 22rem; border: solid 2px; border-color: ${solicitacao.status === 'ACEITO' ? 'blue' : 'red'};">
            <div class="card-body">
                <center><h6 class="card-title"><strong>${solicitacao.razaoSocial}</strong></h6></center>
                <br/>
                <p class="card-title"><strong>CNPJ:</strong> ${solicitacao.cnpj}</p>
                <p class="card-title"><strong>Nome:</strong> ${solicitacao.nome}</p>
                <p class="card-title"><strong>E-mail:</strong> ${solicitacao.email}</p>
                <p class="card-title"><strong>Celular:</strong> ${solicitacao.celular}</p>
                <br/>
                <center><button type="button" class="btn ${solicitacao.status === 'ACEITO' ? 'btn-info' : 'btn-danger'}" disabled data-toggle="modal" data-target="#botaoSolicitar">${solicitacao.status === 'ACEITO' ? 'Aceito' : 'Recusado'}</button></center>
            </div>
        </div>
    `;
}

getSolicitacoesEncerradas();
