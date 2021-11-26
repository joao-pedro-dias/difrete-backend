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
    return `<div class="card" style="width: 18rem;">
                <div class="card-body">
                    <h2 class="card-title">Razão Social: ${fretistaAtivo.razaoSocial}</h2>
                    <h5 class="card-title">CNPJ: ${fretistaAtivo.cnpj}</h5>
                    <p class="card-title">Nome: ${fretistaAtivo.nome}</p>
                    <p class="card-title">E-mail: ${fretistaAtivo.email}</p>
                    <p class="card-title">Celular: ${fretistaAtivo.celular}</p>
                    <button onclick="solicitarServico('${fretistaAtivo.id}')">Solicitar serviço</button>
                </div>
            </div>`;

}

function solicitarServico(fretistaId) {
    axios({
        method: 'post',
        url: `https://localhost:44366/api/solicitacao/${fretistaId}/solicitar`,
    }).then(response => {
        alert('solicitado com sucesso')
        getFretistasAtivos();
    })
}

getFretistasAtivos();
