function nowPlaying(params) {
    let [track, artist, duration] = params;

    console.log(`Now Playing: ${artist} - ${track} [${duration}]`)
}

// nowPlaying(['Number One', 'Nelly', '4:09']);