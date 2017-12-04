<?php

$app->group('/perguntas', function () {
    $this->get('', '\App\Controllers\PerguntasController:listAll');
    $this->post('', '\App\Controllers\PerguntasController:create');
    $this->get('/{id:[0-9]+}', '\App\Controllers\PerguntasController:view');
    $this->put('/{id:[0-9]+}', '\App\Controllers\PerguntasController:update');
    $this->delete('/{id:[0-9]+}', '\App\Controllers\PerguntasController:delete');
});
