<?php
namespace App\Controllers;

use App\Models\Entity\Pergunta;
use App\Models\Entity\Respostas;

require_once 'Base.php';

class PerguntasController extends Base
{
    function getEntityName()
    {
        return 'Pergunta';
    }

    function getNewEntity()
    {
        return new Pergunta();
    }

    function setValues(&$entity, $params)
    {

    }

    function findPergunta($id)
    {
        $repository = $this->getRepositoryByEntity('Pergunta');
        $pergunta = $repository->find($id);
        return $pergunta;
    }

    function findResposta($id)
    {
        $repository = $this->getRepositoryByEntity('Resposta');
        $resposta = $repository->find($id);
        return $resposta;
    }

    function listAll($request, $response, $args)
    {
        $all = $this->findAll();

        $perguntas = array();
        foreach ($all as $pergunta) {
            $sql = 'SELECT r FROM App\Models\Entity\Resposta r WHERE r.pergunta = ?1 ORDER BY r.id ASC';

            $query = $this->getEntityManager()->createQuery($sql)
                ->setParameter(1, $pergunta->id)
                ->getResult();

            foreach ($query as $value) {
                $array = [
                    "id" => $value->id,
                    "texto" => $value->texto,
                ];
                array_push($pergunta->respostas, $array);
            }

            array_push($perguntas, $pergunta);
        }

        $return = $response->withJson($perguntas, 200)
            ->withHeader('Content-type', 'application/json');
        return $return;
    }

    function answer($request, $response, $args)
    {
        $params = (object) $request->getParams();
        $pergunta = $this->findPergunta($params->pergunta);
        $resposta = $this->findResposta($params->resposta);

        $respostas = new Respostas();
        $respostas->setPergunta($pergunta);
        $respostas->setResposta($resposta);

        $this->persist($respostas);

        $return = $response->withJson($respostas, 201)
            ->withHeader('Content-type', 'application/json');
        return $return;
    }

    function results($request, $response, $args)
    {
        $all = $this->findAll();

        $perguntas = array();
        foreach ($all as $pergunta) {

            $value = [
                "id" => $pergunta->id,
                "texto" => $pergunta->texto
            ];

            $sql = "select r1.resposta, r2.texto, count(r1.resposta) total from respostas r1, resposta r2 where r2.id = r1.resposta and r1.pergunta = " . $pergunta->id . " group by r1.resposta";
            $dbQuery = $this->getDbal()->query($sql);
            $result = $dbQuery->fetchAll();

            $resultados = array();
            foreach ($result as $resultado) {
                $resultado = (object) $resultado;
                $res = [
                    "texto" => $resultado->texto,
                    "total" => $resultado->total
                ];

                array_push($resultados, $res);
            }

            $value["resultados"] = $resultados;
            array_push($perguntas, $value);
        }

        $return = $response->withJson($perguntas, 200)
            ->withHeader('Content-type', 'application/json');
        return $return;
    }
}
