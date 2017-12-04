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


    /**
     * Get id
     *
     * @return integer
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Set pergunta
     *
     * @param \Pergunta $pergunta
     *
     * @return Respostas
     */
    public function setPergunta(\Pergunta $pergunta = null)
    {
        $this->pergunta = $pergunta;

        return $this;
    }

    /**
     * Get pergunta
     *
     * @return \Pergunta
     */
    public function getPergunta()
    {
        return $this->pergunta;
    }

    /**
     * Set resposta
     *
     * @param \Resposta $resposta
     *
     * @return Respostas
     */
    public function setResposta(\Resposta $resposta = null)
    {
        $this->resposta = $resposta;

        return $this;
    }

    /**
     * Get resposta
     *
     * @return \Resposta
     */
    public function getResposta()
    {
        return $this->resposta;
    }
}

