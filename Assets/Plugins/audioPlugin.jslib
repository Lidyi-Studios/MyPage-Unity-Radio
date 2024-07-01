mergeInto(LibraryManager.library, {
    PlayAudio: function() {
        if (sound) {
            sound.play();
        } else {
            console.log("El audio no está cargado todavía.");
        }
    },
    PauseAudio: function() {
        if (sound) {
            sound.pause();
        } else {
            console.log("El audio no está cargado todavía.");
        }
    },
});