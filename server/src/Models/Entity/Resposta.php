<?php
namespace App\Models\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Resposta
 *
 * @ORM\Table(name="resposta")
 * @ORM\Entity
 */
class Resposta
{
    /**
     * @ORM\Column(type="integer")
     * @ORM\Id
     * @ORM\GeneratedValue
     */
    public $id;

    /**
     * @ORM\Column(name="texto", type="string", length=255, nullable=false)
     */
    public $texto;

    /**
     * @ORM\ManyToOne(targetEntity="Pergunta", fetch="EAGER")
     * @ORM\JoinColumns({
     *   @ORM\JoinColumn(name="pergunta", referencedColumnName="id")
     * })
     */
    public $pergunta;


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
     * Set texto
     *
     * @param string $texto
     *
     * @return Resposta
     */
    public function setTexto($texto)
    {
        $this->texto = $texto;

        return $this;
    }

    /**
     * Get texto
     *
     * @return string
     */
    public function getTexto()
    {
        return $this->texto;
    }

    /**
     * Set pergunta
     *
     * @param \Pergunta $pergunta
     *
     * @return Resposta
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
}

