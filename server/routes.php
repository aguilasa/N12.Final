<?php

$app->group('/perguntas', function () {
    $this->get('', '\App\Controllers\PerguntasController:listAll');
    $this->post('', '\App\Controllers\PerguntasController:answer');
    $this->get('/resultados', '\App\Controllers\PerguntasController:results');
});
