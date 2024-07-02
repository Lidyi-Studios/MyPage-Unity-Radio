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
    SetVolume: function(volume) {
        if (sound) {
            sound.volume(volume);
        } else {
            console.log("El audio no está cargado todavía.");
        }
    },
    MuteAudio: function() {
        if (sound) {
            sound.muted = true;
        } else {
            console.log("El audio no está cargado todavía.");
        }
    },
    UnmuteAudio: function() {
        if (sound) {
            sound.muted = false;
        } else {
            console.log("El audio no está cargado todavía.");
        }
    },

});