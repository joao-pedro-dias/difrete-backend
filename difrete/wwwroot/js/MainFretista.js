function addCard() {
    axios({
        method: 'get',
        url: 'https://localhost:44366/api/fretista/ativos',
    }).then(response => {
        console.log("Dados da API")
        console.log(response.data)
        console.log(response.data.celular)

        var cardColEl = document.querySelector('#cardDIV');
        var allCardsHTML = "";

        var cardHTML =
            `<div class="card" style="width: 18rem;">
                <div class="card-body">
                    <h2 class="card-title">Razão Social: ${response.data.razaoSocial}</h2>
                    <h5 class="card-title">CNPJ: ${response.data.cnpj}</h5>
                    <p class="card-title">Nome: ${response.data.nome}</p>
                    <p class="card-title">E-mail: ${response.data.email}</p>
                    <p class="card-title">Celular: ${response.data.celular}</p>
                </div>
            </div>`;
        allCardsHTML += cardHTML;
        console.log("cardHTML")
        console.log(cardHTML)

        cardColEl.innerHTML = allCardsHTML;
    })
}
