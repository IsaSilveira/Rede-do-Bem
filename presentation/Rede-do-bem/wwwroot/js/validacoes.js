// ---- MÁSCARAS ----

function mascaraTelefone(input) {
    input.addEventListener('input', function () {
        let v = this.value.replace(/\D/g, '').slice(0, 11);
        if (v.length > 10) v = v.replace(/^(\d{2})(\d{5})(\d{4})$/, '($1) $2-$3');
        else if (v.length > 6) v = v.replace(/^(\d{2})(\d{4})(\d{0,4})/, '($1) $2-$3');
        else if (v.length > 2) v = v.replace(/^(\d{2})(\d{0,5})/, '($1) $2');
        else if (v.length > 0) v = '(' + v;
        this.value = v;
    });
}

function mascaraCPF(input) {
    input.addEventListener('input', function () {
        let v = this.value.replace(/\D/g, '').slice(0, 11);
        v = v.replace(/(\d{3})(\d)/, '$1.$2');
        v = v.replace(/(\d{3})(\d)/, '$1.$2');
        v = v.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
        this.value = v;
    });
}

function mascaraCNPJ(input) {
    input.addEventListener('input', function () {
        let v = this.value.replace(/\D/g, '').slice(0, 14);
        v = v.replace(/^(\d{2})(\d)/, '$1.$2');
        v = v.replace(/^(\d{2})\.(\d{3})(\d)/, '$1.$2.$3');
        v = v.replace(/\.(\d{3})(\d)/, '.$1/$2');
        v = v.replace(/(\d{4})(\d)/, '$1-$2');
        this.value = v;
    });
}

function mascaraHorarioRange(input) {
    input.addEventListener('input', function () {
        let d = this.value.replace(/\D/g, '').slice(0, 8);
        let f = '';
        if (d.length > 0) {
            f = d.slice(0, 2);
            if (d.length > 2) f += ':' + d.slice(2, 4);
            if (d.length > 4) f += ' - ' + d.slice(4, 6);
            if (d.length > 6) f += ':' + d.slice(6, 8);
        }
        this.value = f;
    });
}

// ---- VALIDADORES ----

function validarTelefone(v) {
    const d = v.replace(/\D/g, '');
    return d.length >= 10 && d.length <= 11;
}

function validarCPF(cpf) {
    cpf = cpf.replace(/\D/g, '');
    if (cpf.length !== 11 || /^(\d)\1+$/.test(cpf)) return false;
    let s = 0, r;
    for (let i = 0; i < 9; i++) s += +cpf[i] * (10 - i);
    r = (s * 10) % 11; if (r >= 10) r = 0;
    if (r !== +cpf[9]) return false;
    s = 0;
    for (let i = 0; i < 10; i++) s += +cpf[i] * (11 - i);
    r = (s * 10) % 11; if (r >= 10) r = 0;
    return r === +cpf[10];
}

function validarCNPJ(cnpj) {
    cnpj = cnpj.replace(/\D/g, '');
    if (cnpj.length !== 14 || /^(\d)\1+$/.test(cnpj)) return false;
    const calc = (n, l) => {
        let s = 0, p = l - 7;
        for (let i = l; i >= 1; i--) { s += +n[l - i] * p--; if (p < 2) p = 9; }
        const r = s % 11; return r < 2 ? 0 : 11 - r;
    };
    return calc(cnpj, 12) === +cnpj[12] && calc(cnpj, 13) === +cnpj[13];
}

function validarHora(v) {
    const m = v.match(/^(\d{2}):(\d{2})$/);
    return !!(m && +m[1] <= 23 && +m[2] <= 59);
}

function validarHorarioRange(v) {
    if (!v.trim()) return false;
    const parts = v.split(' - ');
    if (!validarHora(parts[0])) return false;
    if (parts.length === 1) return true;
    if (!validarHora(parts[1])) return false;
    const [h1, m1] = parts[0].split(':').map(Number);
    const [h2, m2] = parts[1].split(':').map(Number);
    return h2 * 60 + m2 > h1 * 60 + m1;
}

// ---- AUTOCOMPLETE DE ENDEREÇO (Nominatim/OpenStreetMap) ----

(function () {
    const style = document.createElement('style');
    style.textContent = [
        '.sugestoes-endereco{position:absolute;z-index:9999;max-height:220px;overflow-y:auto;',
        'border-radius:8px;box-shadow:0 4px 10px rgba(0,0,0,.18);display:none;background:#fff;',
        'margin:0;padding:0;list-style:none;color:#222 !important;}',
        '.sugestoes-endereco li{cursor:pointer;font-size:14px;padding:8px 12px;',
        'border-bottom:1px solid #eee;color:#222 !important;background:#fff;}',
        '.sugestoes-endereco li:last-child{border-bottom:none;}',
        '.sugestoes-endereco li:hover{background:#f0f0f0 !important;}'
    ].join('');
    document.head.appendChild(style);
})();

function _formatarEnderecoNominatim(item, queryDigitada) {
    const a = item.address || {};
    const partes = [];

    if (a.road) {
        // 1º: número vindo do banco OSM
        let num = a.house_number;

        // 2º: número como prefixo do display_name ("1200, Rua Augusta, ...")
        if (!num) {
            const m = item.display_name.match(/^(\d[\d\w-]*),/);
            if (m) num = m[1];
        }

        // 3º: número que o usuário digitou na query (ex: "Rua Augusta 1200")
        if (!num && queryDigitada) {
            const m = queryDigitada.match(/\b(\d{1,6})\b/);
            if (m) num = m[1];
        }

        partes.push(num ? a.road + ' ' + num : a.road);
    }

    const bairro = a.suburb || a.neighbourhood || a.quarter;
    if (bairro) partes.push(bairro);
    const cidade = a.city || a.town || a.village || a.municipality;
    if (cidade) partes.push(cidade);
    const estado = a.state_code
        || (a['ISO3166-2-lvl4'] ? a['ISO3166-2-lvl4'].replace('BR-', '') : null)
        || a.state;
    if (estado) partes.push(estado);

    return partes.length ? partes.join(' - ') : item.display_name;
}

function initEnderecoAutocomplete(inputEl, onSelect) {
    if (!inputEl) return;

    // Anexa ao body para escapar de qualquer overflow:hidden ou z-index de pai
    const lista = document.createElement('ul');
    lista.className = 'sugestoes-endereco';
    document.body.appendChild(lista);

    function posicionar() {
        const r = inputEl.getBoundingClientRect();
        lista.style.top   = (r.bottom + window.scrollY) + 'px';
        lista.style.left  = (r.left   + window.scrollX) + 'px';
        lista.style.width = r.width + 'px';
    }

    let timeout = null;

    function esconder() {
        lista.innerHTML = '';
        lista.style.display = 'none';
    }

    inputEl.addEventListener('input', function () {
        clearTimeout(timeout);
        onSelect(false);
        const query = inputEl.value.trim();
        if (query.length < 3) { esconder(); return; }

        timeout = setTimeout(async () => {
            try {
                const url = 'https://nominatim.openstreetmap.org/search?format=json&limit=7&addressdetails=1&countrycodes=br&q=' +
                    encodeURIComponent(query);
                const res = await fetch(url);
                const data = await res.json();
                lista.innerHTML = '';
                if (!data.length) { esconder(); return; }
                posicionar();
                data.forEach(item => {
                    const label = _formatarEnderecoNominatim(item, query);
                    const li = document.createElement('li');
                    li.textContent = label;
                    li.addEventListener('click', () => {
                        inputEl.value = label;
                        esconder();
                        onSelect(true);
                    });
                    lista.appendChild(li);
                });
                lista.style.display = 'block';
            } catch { esconder(); }
        }, 400);
    });

    window.addEventListener('scroll', posicionar, true);
    window.addEventListener('resize', posicionar);

    document.addEventListener('click', function (e) {
        if (!inputEl.contains(e.target) && !lista.contains(e.target)) esconder();
    });
}

// ---- HELPERS DE ERRO ----

function setErro(form, fieldName, msg) {
    const span = form.querySelector('[data-valmsg-for="' + fieldName + '"]');
    if (span) { span.textContent = msg; span.className = 'text-danger small'; }
}

function clearErro(form, fieldName) {
    const span = form.querySelector('[data-valmsg-for="' + fieldName + '"]');
    if (span) { span.textContent = ''; }
}
