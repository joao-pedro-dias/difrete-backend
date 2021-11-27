function getSolicitacoesPendentes() {
    axios({
        method: 'get',
        url: 'https://localhost:44366/api/solicitacao/pendentes/fretista',
    }).then(response => {

        const container = $('#container');

        const cards = response.data.map((solicitacao, index) => getCard(solicitacao, index))

        container.html(cards);
    })
}

function getCard(solicitacao, index) {
    //TODO: MUDAR MENSAGEM, ajustar margin
    return `
        <div class="card" style="width: 22rem; border: solid 2px; border-color: blue;">
            <div class="card-body">
                <center><h6 class="card-title"><strong>${solicitacao.nome}</strong></h6></center>
                <br/>
                <p class="card-title"><strong>E-mail:</strong> ${solicitacao.email}</p>
                <p class="card-title"><strong>Celular:</strong> ${solicitacao.celular}</p>
                <br/>
                <center><button type="button" class="btn btn-success" data-toggle="modal" data-target="#botaoAceitar${index}">Aceitar</button>
                <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#botaoRecusar${index}">Recusar</button></center>
            </div>
        </div>

        <div class="modal fade" id="botaoAceitar${index}" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                <h5 class="modal-title" id="staticBackdropLabel">Deseja aceitar a solicitação?</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                <p>Aceitando a solicitação o contratante ficará ciente que você realizará o serviço.</p>
                </div>
                <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Voltar</button>
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick="aceitarServico('${solicitacao.id}')">Sim, aceitar!</button>
                </div>
            </div>
            </div>
        </div>

        <div class="modal fade" id="botaoRecusar${index}" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                <h5 class="modal-title" id="staticBackdropLabel">Deseja recusar a solicitação?</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                <p>Recusando a solicitação o contratante ficará ciente que você não realizará o serviço.</p>
                </div>
                <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Voltar</button>
                <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="recusarServico('${solicitacao.id}')">Recusar</button>
                </div>
            </div>
            </div>
        </div>
    `;
}

function recusarServico(solicitacaoId) {
    axios({
        method: 'patch',
        url: `https://localhost:44366/api/solicitacao/${solicitacaoId}/recusar`,
    }).then(response => {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Sucesso!',
            text: 'Solicitação recusada.',
            showConfirmButton: false,
            timer: 3500
        })
        getSolicitacoesPendentes();
    })
}

function aceitarServico(solicitacaoId) {
    axios({
        method: 'patch',
        url: `https://localhost:44366/api/solicitacao/${solicitacaoId}/aceitar`,
    }).then(response => {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Sucesso!',
            text: 'Solicitação aceita.',
            showConfirmButton: false,
            timer: 3500
        })
        getSolicitacoesPendentes();
    })
}

getSolicitacoesPendentes();
