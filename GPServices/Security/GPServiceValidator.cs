using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.ServiceModel;
using System.IdentityModel.Selectors;
using System.IdentityModel;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;


namespace GPServices.Security
{
     
    public class GPServiceValidator : UserNamePasswordValidator
    {
        const string ENTITY_EXCEPTION_EM = "Сервис доступен, но попытка получения данных от БД не удалась. Источник ошибки: {0}. Сервис: {1}. Метод: {2} Внутренняя ошибка: {3}";
        const string VALIDATION_EXCEPTION_EM = "Ошибка при валидации данных (при попытке сохраниния в БД). Проверьте длины строк и убедитесь в их соответствии. Источник ошибки: {0}. Сервис: {1}. Метод: {2} Внутренняя ошибка: {3}";
        const string DB_UPDATE_EXCEPRION_EM = "Ошибка при попытке сохранения данных. Возможны нарушения ограничений. Источник ошибки: {0}. Сервис: {1}. Метод: {2} Внутренняя ошибка: {3}";
        const string SERVICE_NAME = "GPServices.Security";
        public override void Validate(string userName, string password)
        {
            string methodName = "Validate";

            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }
            
            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    GPUser user = gpe.GPUsers.Where(u => u.UserName == userName && u.UserPassword == password).FirstOrDefault();
                    if (user == null)
                    {
                        throw new FaultException("Password or name is wrong");
                    }
                    
                }

            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            
        }
    }
}
