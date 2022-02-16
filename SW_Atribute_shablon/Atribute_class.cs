namespace Attribute_libs
{
    public class Atribute_class
    {
        #region // Переменные шаблона
        private int atribute_for_exp;       // счетчик прокачки атрибута персонажа за очки опыта
        private int atribute_for_atr;       // счетчик прокачки атрибута персонажа за очки атрибутов
        private int score;                  // значение атрибута персонажа
        private int atr_limit;              // лимит прокачки атрибутов персонажа
        private int Error_code;             // Код ошибки, возникающей при управлении атрибутом персонажа
        private int age_attribute_limit;    // Лимит атрибута исходя из возраста персонажа
        private int range_attribute_limit;  // Лимит атрибута исходя из ранга персонажа

        private int child_attribute_limit;  // Возрастной лимит атрибутов для ребенка
        private int teen_attribute_limit;   // Возрастной лимит атрибутов для подростка
        private int adult_attribute_limit;  // Возрастной лимит атрибутов для взрослого
        private int middle_attribute_limit; // Возрастной лимит атрибутов для среднего возраста
        private int old_attribute_limit;    // Возрастной лимит атрибутов для старого возраста
        private int eldery_attribute_limit; // Возрастной лимит атрибутов для пожилого возраста
        private int unknown_age_attribute_limit; // Возрастной лимит атрибутов для неизвестного возраста

        private int Private_range_limit;    // Лимит атрибутов по рангу Рядовой
        private int Veteran_range_limit;    // Лимит атрибутов по рангу Ветеран
        private int Hero_range_limit;       // Лимит атрибутов по рангу Герой
        private int Epic_range_limit;       // Лимит атрибутов по рангу Эпик
        private int Immortal_range_limit;   // Лимит атрибутов по рангу Бессмертный

        private int atribute_code;          // Код атрибута

        private string description;         // описание атрибута персонажа
        private string Error_msg;

        private string path_read_description; // Путь к файлу для вычитывания текстового описания атрибута

        
        #endregion

        #region // Конструктор шаблона
        public Atribute_class()
        {
            atribute_for_atr = 0;           // устанавливаем значение счетчика прокачки за очки атрибутов
            atribute_for_exp = 0;           // устанавливаем значение счетчика прокачки за очки опыта
            Set_error_code(0);
        }
        #endregion

        #region // Методы шаблона
        private void Set_error_code(int insert_value) { Error_code = insert_value; }
        public string Get_error_msg()
        {
            switch(Error_code)
            {
                case 0: 
                    Error_msg = ""; 
                    break;
                case 1:
                    Error_msg = "Нет возможности увеличить значение данного атрибута!";
                    break;
                case 2:
                    Error_msg = "Достигнут лимит улучшения атрибута!";
                    break;
                case 3:
                    Error_msg = "Нельзя уменьшить значение атрибута ниже 0!";
                    break;
                case 4:
                    Error_msg = "Нельзя уменьшить значение атрибута ниже расового бонуса!";
                    break;
            }
            return Error_msg;
        }
        private void Increase_atr_for_exp() { atribute_for_exp = atribute_for_exp + 1; }
        private void Decrease_atr_for_exp() { atribute_for_exp = atribute_for_exp - 1; }
        private int Get_atr_for_exp() { return atribute_for_exp; }
        private void Increase_atr_for_atr() { atribute_for_atr = atribute_for_atr + 1; }
        private void Decrease_atr_for_atr() { atribute_for_atr = atribute_for_atr - 1; }
        private int Get_atr_for_atr() { return atribute_for_atr; }
        /*
        public void Increase_atr() 
        {
            // Считаем условиие как сумму счетчиков прокачки. таким образом избегаем влияния расовых бонусов
            if ((Get_atr_for_atr() + Get_atr_for_exp()) < Get_Atr_limit())
            {
                if (_SW_Char.Get_attribute() >= 1)
                {
                    score = score + 1;
                    Increase_atr_for_atr();
                    _SW_Char.Decrease_attribute_on(1);
                    Set_error_code(0);

                }
                else if (_SW_Char.Get_experience() >= 8)
                {
                    score = score + 1;
                    Increase_atr_for_exp();
                    _SW_Char.Decrease_experience_on(8);
                    Set_error_code(0);
                }
                else
                {
                    Set_error_code(1);      // тут сообщение о том, что не хватает возможности качнуть атрибут
                }
            }
            else
            {
                Set_error_code(2);          // тут сообщение о том, что достигнут лимит прокачки атрибута
            }
        }
        */
        public void Increase_atr(int insert_value) { score = score + insert_value; }
        /*
        public void Decrease_atr() 
        {
            if ((Get_atr_for_atr() != 0) || (Get_atr_for_exp() != 0))
            {
                if (Get_atr_for_atr() > 0)
                {
                    Decrease_atr_for_atr();
                    _SW_Char.Increase_attribute_on(1);
                    score = score - 1;
                    Set_error_code(0);
                }
                else if ((Get_atr_for_atr() == 0) && (Get_atr_for_exp() > 0))
                {
                    Decrease_atr_for_exp();
                    _SW_Char.Increase_experience_on(8);
                    score = score - 1;
                    Set_error_code(0);
                }
            }
            else
            {
                if (((Get_atr_for_exp() + Get_atr_for_atr()) == 0) && (score == 0)) 
                {
                    Set_error_code(3);      // тут сообщение о том, что нельзя уменьшить значение атрибута ниже 0
                }
                else if (((Get_atr_for_exp() + Get_atr_for_atr()) == 0) && (score != 0))
                {
                    Set_error_code(4);      // тут сообщение о том, что нельзя уменьшить значение атрибута ниже расового бонуса
                }
            }
        }
        */
        public void Decrease_atr(int insert_value) { score = score - insert_value; }
        public void Set_atr_score(int insert_value) { score = insert_value; }
        public int Get_atribute_score() { return score; }
        public void Set_description(string insert_text) { description = insert_text; }
        public string Get_description () { return description; }

        #region //Лимит значения атрибута по возрасту персонажа
        public void Set_child_attribute_limit       (int insert_int) { child_attribute_limit = insert_int; }                public int Get_child_attribute_limit()          { return child_attribute_limit; }
        public void Set_teen_attribute_limit        (int insert_int) { teen_attribute_limit = insert_int; }                 public int Get_teen_attribute_limit()           { return teen_attribute_limit; }
        public void Set_adult_attribute_limit       (int insert_int) { adult_attribute_limit = insert_int; }                public int Get_adult_attribute_limit()          { return adult_attribute_limit; }
        public void Set_middle_attribute_limit      (int insert_int) { middle_attribute_limit = insert_int; }               public int Get_middle_attribute_limit()         { return middle_attribute_limit; }
        public void Set_old_attribute_limit         (int insert_int) { old_attribute_limit = insert_int; }                  public int Get_old_attribute_limit()            { return old_attribute_limit; }
        public void Set_eldery_attribute_limit      (int insert_int) { eldery_attribute_limit = insert_int; }               public int Get_eldery_attribute_limit()         { return eldery_attribute_limit; }
        public void Set_unknown_age_attribute_limit (int insert_int) { unknown_age_attribute_limit = insert_int; }          public int Get_unknown_age_attribute_limit()    { return unknown_age_attribute_limit; }
        /*
        public void Set_age_attribute_limit(string age_status)
        {
            foreach (Age_status_class Age_status in _SW_Char._Age_statuses)
            {
                if (Age_status.Get_age_status_name() == age_status)
                {
                    switch (Age_status.Get_age_status_code())
                    {
                        case (int)SW_Character.enum_Age_status.Child:   age_attribute_limit = Get_child_attribute_limit();      break; //2
                        case (int)SW_Character.enum_Age_status.Teen:    age_attribute_limit = Get_teen_attribute_limit();       break; //4
                        case (int)SW_Character.enum_Age_status.Adult:   age_attribute_limit = Get_adult_attribute_limit();      break; //10
                        case (int)SW_Character.enum_Age_status.Middle:  age_attribute_limit = Get_middle_attribute_limit();     break; //10
                        case (int)SW_Character.enum_Age_status.Old:     age_attribute_limit = Get_old_attribute_limit();        break; //10
                        case (int)SW_Character.enum_Age_status.Eldery:  age_attribute_limit = Get_eldery_attribute_limit();     break; //10
                        case (int)SW_Character.enum_Age_status.Unknown: age_attribute_limit = Get_unknown_age_attribute_limit(); break; //0
                    }
                    break;
                }
            }
            
        }
        */
        public int Get_age_attribute_limit() { return age_attribute_limit; }
        #endregion

        #region //Лимит значения атрибута по рангу персонажа
        public void Set_private_range_attribute_limit   (int insert_int) { Private_range_limit = insert_int; }          public int Get_private_range_attribute_limit()  { return Private_range_limit; }
        public void Set_veteran_range_attribute_limit   (int insert_int) { Veteran_range_limit = insert_int; }          public int Get_veteran_range_attribute_limit()  { return Veteran_range_limit; }
        public void Set_hero_range_attribute_limit      (int insert_int) { Hero_range_limit = insert_int; }             public int Get_hero_range_attribute_limit()     { return Hero_range_limit; }
        public void Set_epic_range_attribute_limit      (int insert_int) { Epic_range_limit = insert_int; }             public int Get_epic_range_attribute_limit()     { return Epic_range_limit; }
        public void Set_immortal_range_attribute_limit  (int insert_int) { Immortal_range_limit = insert_int; }         public int Get_immortal_range_attribute_limit() { return Immortal_range_limit; }

        /*
        public void Set_range_attribute_limit(string insert_range)
        {
            foreach (Range_Class _Range in _SW_Char._Ranges)
            {
                if (_Range.Get_range_name() == insert_range)
                {
                    switch (_Range.Get_range_code())
                    {
                        case (int)SW_Character.enum_Range.Private:
                            range_attribute_limit = Get_private_range_attribute_limit();
                            break;
                        case (int)SW_Character.enum_Range.Veteran:
                            range_attribute_limit = Get_veteran_range_attribute_limit();
                            break;
                        case (int)SW_Character.enum_Range.Hero:
                            range_attribute_limit = Get_hero_range_attribute_limit();
                            break;
                        case (int)SW_Character.enum_Range.Epic:
                            range_attribute_limit = Get_epic_range_attribute_limit();
                            break;
                        case (int)SW_Character.enum_Range.Immortal:
                            range_attribute_limit = Get_immortal_range_attribute_limit();
                            break;
                    }
                    break;
                }
            }
        }
        */
        public int Get_range_attribute_limit() { return range_attribute_limit; }
        #endregion

        #region //Сравнение лимитов атрибутов. Используем меньший лимит
        public int Atr_limit(int age_limit, int range_limit)
        {
            if (age_limit >= range_limit)
            {
                atr_limit = range_limit;
            }
            else if (range_limit > age_limit)
            {
                atr_limit = age_limit;
            }
            else
            {
                atr_limit = 0;
            }
            return atr_limit;
        }

        public int Get_Atr_limit() { return atr_limit; }

        public void Set_atribute_code(int insert_int) { atribute_code = insert_int; }
        public int Get_atribute_code() { return atribute_code; }
        #endregion

        #endregion

    }
}
