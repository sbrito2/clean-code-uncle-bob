SELECT "BET_ID", "BET_NAME", "BET_DESCRIPTION", "COG_ID"
	FROM public."BEVERAGE_TYPE";
	
select * from "BEVERAGE_TYPE"

insert into "BEVERAGE_TYPE" OVERRIDING SYSTEM VALUE values (1, 'Cappuccino', 'Sua receita inclui uma dose de café espresso misturado com leite vaporizado, espuma de leite e chocolate em pequenos pedaços ou em pó sobre a bebida', null)

delete from "BEVERAGE_TYPE"
where "BET_ID" = 1

insert into "BEVERAGE_TYPE" ("BET_NAME", "BET_DESCRIPTION", "COG_ID")
values ('Café Macchiato', 'O macchiato é muito parecido com o café espresso, mas adiciona uma dose de leite vaporizado para suavizar o sabor intenso do espresso', null)

update "BEVERAGE_TYPE" 
set "BET_DESCRIPTION" = 'utiliza-se leite vaporizado misturado a uma dose de café espresso, além de 1 centímetro de espuma de leite servido sobre a bebida'
where "BET_ID" = 4

select * from "COFFE"
insert into "COFFE" ("COF_COUNTRY", "COF_DESCRIPTION") values ('Brasil', null), ('Colomnbia', null), ('Indonésia', null), ('Etiópia', null),
('Índia', null), ('Panamá', null)

select * from "BEVERAGE" 
insert into "BEVERAGE" ("BET_ID", "COF_ID", "BEV_MILK", "BEV_SOY", "BEV_DATE") values (1, 1, true, true, '2020-04-26'),
(1, 1, true, false, '2020-04-26'), (2, 1, true, true, '2020-04-26'), (2, 1, false, true, '2020-04-27')

Logs de emergencia:
 - sensenha de panico: guarda o id da pessoa que solicitou e o setor
 - invinvasor pelo muro: solicita a camera e dela guarda o setor dela e a camera
