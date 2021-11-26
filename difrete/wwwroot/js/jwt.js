function getJwt() {
    const currentJwt = localStorage.getItem('jwt');
    if (currentJwt) {
        return jwt_decode(currentJwt)
    }
    return {}
}

function isJwtExpired() {
    const jwt = getJwt();
    return new Date(jwt.exp) > new Date();
}

function isFretista() {
    const jwt = getJwt();
    return jwt.role === 'FRETISTA';
}

function isContratante() {
    const jwt = getJwt();
    return jwt.role === 'CONTRATANTE';
}

function guardarJwt(jwt) {
    localStorage.setItem('jwt', jwt)
}

function removerJwt() {
    localStorage.removeItem('jwt')
}
