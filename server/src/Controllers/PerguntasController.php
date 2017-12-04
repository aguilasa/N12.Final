<?php
namespace App\Controllers;

use \Psr\Http\Message\ServerRequestInterface as Request;
use \Psr\Http\Message\ResponseInterface as Response;

use App\Models\Entity\Pergunta;
use App\Models\Entity\Reposta;
use App\Models\Entity\Respostas;

require_once 'Base.php';

class PerguntasController extends Base
{
    const esperado = array(0, 4, 2, 1, 1);

    public function getEntityName()
    {
        return 'Pergunta';
    }
  
    public function getNewEntity()
    {
        return new Pergunta();
    }
  
    public function setValues(&$entity, $params)
    {
        
    }

    private function findPergunta($id)
    {
        $repository = $this->getRepositoryByEntity('Pergunta');
        $pergunta = $repository->find($id);
        return $pergunta;
    }

    private function findResposta($id)
    {
        $repository = $this->getRepositoryByEntity('Resposta');
        $resposta = $repository->find($id);
        return $resposta;
    }

    public function listAll($request, $response, $args)
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
                    "texto" => $value->texto
                ];
                array_push($pergunta->respostas, $array);
            }

            array_push($perguntas, $pergunta);
        }

        $return = $response->withJson($perguntas, 200)
            ->withHeader('Content-type', 'application/json');
        return $return;
    }

    public function answer($request, $response, $args)
    {
        $params = (object) $request->getParams();
        $pergunta = $this->findPergunta($params->pergunta);
        $resposta = $this->findResposta($params->resposta);

        $respostas = new Respostas();
        $respostas->setPergunta($pergunta);
        $respostas->setResposta($resposta);

        $return = $response->withJson($respostas, 200)
            ->withHeader('Content-type', 'application/json');
        return $return;
    }
}
