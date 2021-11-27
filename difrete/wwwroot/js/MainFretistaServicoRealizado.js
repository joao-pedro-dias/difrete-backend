function getSolicitacoesEncerradas() {
    axios({
        method: 'get',
        url: 'https://localhost:44366/api/solicitacao/encerradas/fretista',
    }).then(response => {

        const container = $('#container');

        const cards = response.data.map(solicitacao => getCard(solicitacao))

        container.html(cards);
    })
}

function getCard(solicitacao) {
    return `
        <div class="card" style="width: 22rem; border: solid 2px; border-color: ${solicitacao.status === 'ACEITO' ? 'blue' : 'red'};">
            <div class="card-body">
                <center><h6 class="card-title"><strong>${solicitacao.nome}</strong></h6></center>
                <br/>
                <p class="card-title"><strong>E-mail:</strong> ${solicitacao.email}</p>
                <p class="card-title"><strong>Celular:</strong> ${solicitacao.celular}</p>
                <br />
                <center><button type="button" class="btn ${solicitacao.status === 'ACEITO' ? 'btn-info' : 'btn-danger'}" disabled>${solicitacao.status === 'ACEITO' ? 'Aceito' : 'Recusado'}</button></center>
            </div>
        </div>
    `;
}

getSolicitacoesEncerradas();
