function getFretistasAtivos() {
    axios({
        method: 'get',
        url: 'https://localhost:44366/api/fretista/ativos',
    }).then(response => {

        const container = $('#cardDIV');

        const cards = response.data.map(fretistaAtivo => getCard(fretistaAtivo))

        container.html(cards);
    })
}

function getCard(fretistaAtivo) {
    return `
        <div class="card" style="width: 22rem; border: solid 2px; border-color: green;">
            <div class="card-body">
                <center><h6 class="card-title"><strong>${fretistaAtivo.razaoSocial}</strong></h6></center>
                <br/>
                <p class="card-title"><strong>CNPJ:</strong> ${fretistaAtivo.cnpj}</p>
                <p class="card-title"><strong>Nome:</strong> ${fretistaAtivo.nome}</p>
                <p class="card-title"><strong>E-mail:</strong> ${fretistaAtivo.email}</p>
                <p class="card-title"><strong>Celular:</strong> ${fretistaAtivo.celular}</p>
                <br/>
                <center><button type="button" class="btn btn-success" data-toggle="modal" data-target="#botaoSolicitar">Solicitar serviço</button></center>
            </div>
        </div>

        <div class="modal fade" id="botaoSolicitar" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                <h5 class="modal-title" id="staticBackdropLabel">Deseja enviar a solicitação?</h5>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                <p>Enviando a solicitação o fretista ficará ciente que você precisa de um serviço. Aguarde até que o mesmo confirme a sua solicitação.</p>
                </div>
                <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Voltar</button>
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick="solicitarServico('${fretistaAtivo.id}')">Sim</button>
                </div>
            </div>
            </div>
        </div>
    `;
}


function solicitarServico(fretistaId) {
    axios({
        method: 'post',
        url: `https://localhost:44366/api/solicitacao/${fretistaId}/solicitar`,
    }).then(response => {
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Solicitação enviada com sucesso!',
            text: 'Solicitação com o status pendente.',
            showConfirmButton: false,
            timer: 3500
        })
        getFretistasAtivos();
    })
}

getFretistasAtivos();
