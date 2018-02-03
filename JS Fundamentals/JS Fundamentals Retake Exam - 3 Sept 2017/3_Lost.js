function lost(keyword, text) {
    function escapeRegExp(str) {
        return str.replace(/[\-\[\]\/\{\}\(\)\*\+\?\.\\\^\$\|]/g, "\\$&");
    }
    keyword = escapeRegExp(keyword);
    const regexCoordinates = /(north|east)[^0-9]*(\d{2})[^,]*,[^0-9]*(\d{6})/gmi;
    const regexMsg = new RegExp(`${keyword}(.+)${keyword}`, "gmi");

    let locStore = new Map();
    let message = "";

    while ((m = regexCoordinates.exec(text)) !== null) {
        let direction = m[1];
        let d1 = m[2];
        let d2 = m[3];
        if (!locStore.has(direction.toLowerCase())) {
            locStore.set(direction.toLowerCase(), []);
        }

        locStore.get(direction.toLowerCase()).push(`${d1}.${d2} ${direction[0].toUpperCase()}`);
    }

    while ((m = regexMsg.exec(text)) !== null) {
        message += m[1];
    }

    console.log(locStore.get("north").pop());
    console.log(locStore.get("east").pop());
    console.log(`Message: ${message}`);
}

// lost("<>", "o u%&lu43t&^ftgv><nortH4276hrv756dcc,  jytbu64574655k <>ThE sanDwich is iN the refrIGErator<>yl i75evEAsTer23,lfwe 987324tlblu6b");
lost("encrKey/", `east eastnorth east29north 43,456789
north one east 40,000000 encrKey/To live is the rarest thing in the world. Most people exist, that is allencrKey/`);