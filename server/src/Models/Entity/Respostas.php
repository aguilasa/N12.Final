<?php
namespace App\Models\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Respostas
 *
 * @ORM\Table(name="respostas")
 * @ORM\Entity
 */
class Respostas
{
    /**
     * @ORM\Column(type="integer")
     * @ORM\Id
     * @ORM\GeneratedValue
     */
    public $id;

    /**
     * @ORM\ManyToOne(targetEntity="Pergunta", fetch="EAGER")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="pergunta", referencedColumnName="id")
     * })
     */
    public $pergunta;

    /**
     * @ORM\ManyToOne(targetEntity="Resposta", fetch="EAGER")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="resposta", referencedColumnName="id")
     * })
     */
    public $resposta;


    public function getId()
    {
        return $this->id;
    }

    public function setPergunta(Pergunta $pergunta = null)
    {
        $this->pergunta = $pergunta;

        return $this;
    }

    public function getPergunta()
    {
        return $this->pergunta;
    }

    public function setResposta(Resposta $resposta = null)
    {
        $this->resposta = $resposta;

        return $this;
    }

    public function getResposta()
    {
        return $this->resposta;
    }
}

