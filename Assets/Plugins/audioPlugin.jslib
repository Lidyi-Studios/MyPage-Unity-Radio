var sound = null;

mergeInto(LibraryManager.library, {
    LoadAudio: function() {
        var howlerScript = document.createElement('script');
        howlerScript.src = "StreamingAssets/howler.core.min.js";
        document.head.appendChild(howlerScript);

        howlerScript.onload = function() {
            // Crear el contexto de audio después de la carga de howler.js
            var audioContext = new (window.AudioContext || window.webkitAudioContext)();

            // Asegurarse de que el contexto de audio se reanude después de una interacción del usuario
            document.addEventListener('click', function() {
                audioContext.resume().then(function() {
                    sound = new Howl({
                        // Evitar el almacenamiento en caché de la URL del audio
                        src: 'https://lidyi.com/radio/server.mp3' + '?' + new Date().getTime(),
                        format: ['mp3'],
                        html5: true // Asegura que el audio se cargue como HTML5 Audio
                    });

                    sound.on('loaderror', function(id, error) {
                        console.error('Error al cargar el audio:', error);
                    });
                });
            }, { once: true }); // Este event listener solo se ejecutará una vez
        }
    },
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