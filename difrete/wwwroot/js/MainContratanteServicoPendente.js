function getSolicitacoesPendentes() {
    axios({
        method: 'get',
        url: 'https://localhost:44366/api/solicitacao/pendentes',
    }).then(response => {

        const container = $('#container');

        const cards = response.data.map((solicitacao, index) => getCard(solicitacao, index))

        container.html(cards);
    })
}

function getCard(solicitacao, index) {
    //TODO: MUDAR MENSAGEM, ajustar margin
    return `
        <div class="card" style="width: 22rem; border: solid 2px; border-color: purple;">
            <div class="card-body">
                <center><h6 class="card-title"><strong>${solicitacao.razaoSocial}</strong></h6></center>
                <br/>
                <p class="card-title"><strong>CNPJ:</strong> ${solicitacao.cnpj}</p>
                <p class="card-title"><strong>Nome:</strong> ${solicitacao.nome}</p>
                <p class="card-title"><strong>E-mail:</strong> ${solicitacao.email}</p>
                <p class="card-title"><strong>Celular:</strong> ${solicitacao.celular}</p>
                <br/>
                <center><button type="button" class="btn btn-dark" data-toggle="modal" data-target="#botaoSolicitar${index}">Excluir serviço</button></center>
            </div>
        </div>

        <div class="modal fade" id="botaoSolicitar${index}" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel">Deseja excluir a solicitação?</h5>
                    <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                    <p>Excluindo a solicitação o fretista ficará ciente que você não quer mais o serviço.</p>
                    </div>
                    <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Voltar</button>
                    <button type="button" class="btn btn-dark" data-dismiss="modal" onclick="excluirServico('${solicitacao.id}')">Sim, excluir!</button>
                    </div>
                </div>
            </div>
        </div>
    `;
}


function excluirServico(solicitacaoId) {
    axios({
        method: 'delete',
        url: `https://localhost:44366/api/solicitacao/${solicitacaoId}/excluir`,
    }).then(response => {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Solicitação excluída!',
            showConfirmButton: false,
            timer: 3500
        })
        getSolicitacoesPendentes();
    })
}

getSolicitacoesPendentes();
