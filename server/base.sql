CREATE TABLE `pergunta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `texto` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `resposta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pergunta` int(11) NOT NULL,
  `texto` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `resposta_pergunta_fk` (`pergunta`),
  CONSTRAINT `resposta_pergunta_fk` FOREIGN KEY (`pergunta`) REFERENCES `pergunta` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `respostas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pergunta` int(11) NOT NULL,
  `resposta` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `respostas_pergunta_fk` (`pergunta`),
  KEY `respostas_resposta_fk` (`resposta`),
  CONSTRAINT `respostas_pergunta_fk` FOREIGN KEY (`pergunta`) REFERENCES `pergunta` (`id`),
  CONSTRAINT `respostas_resposta_fk` FOREIGN KEY (`resposta`) REFERENCES `resposta` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

