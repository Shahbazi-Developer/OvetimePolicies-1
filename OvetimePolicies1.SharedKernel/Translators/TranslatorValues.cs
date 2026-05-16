namespace OvetimePolicies1.SharedKernel.Translators;

public class TranslatorValues
{
    #region ValidationMessage

    public const string VALIDATION_ERROR_REQUIRED = "مقدار {0} اجباری می باشد";
    public const string VALIDATION_ERROR_NOT_EXIST = "{0} وجود ندارد.";
    public const string VALIDATION_ERROR_NOT_EXIST_ANY = "{0} وجود ندارد.";
    public const string VALIDATION_ERROR_DUPLICATE = "{0} تکراری است.";
    public const string VALIDATION_ERROR_NOT_VALID = "مقدار {0} نامعتبر است.";
    public const string VALIDATION_ERROR_NOT_EQUAL_TO = "{0} برابر {1} نیست.";
    public const string VALIDATION_ERROR_FORMAT = "فرمت {0} وارد شده صحیح نمی باشد.";
    public const string VALIDATION_ERROR_NOT_POSSIBLE_TO_DELETE_USED_ITEM = "حذف {0} استفاده شده امکان پذیر نمی باشد.";
    public const string VALIDATION_ERROR_CHANGE_STATUS = "تغییر وضعیت {0} امکان پذیر نیست.";

    public const string VALIDATION_ERROR_NUMBER_BETWEEN = "{0} باید بین {1} و {2} باشد.";
    public const string VALIDATION_ERROR_NUMBER_LESS_THAN = "مقدار {0} باید کوچکتر از {1} باشد.";
    public const string VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN = "مقدار {0} باید کوچکتر یا مساوی {1} باشد.";
    public const string VALIDATION_ERROR_NUMBER_GRATER_THAN = "مقدار {0} باید بزرگتر از {1} باشد.";
    public const string VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN = "مقدار {0} باید بزرگتر یا مساوی {1} باشد.";
    public const string VALIDATION_ERROR_MUST_BE_NUMERIC = "{0} باید عددی باشد.";

    public const string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = "طول مناسب برای {0} بزرگتر از {1} و کوچکتر یا مساوی {2} می باشد.";
    public const string VALIDATION_ERROR_STRING_MIN_LENGTH = "{0} باید حداقل {1} کاراکتر باشد.";
    public const string VALIDATION_ERROR_STRING_MAX_LENGTH = "{0} باید حداکثر {1} کاراکتر باشد.";
    public const string VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL = "طول {0} باید برابر {1} باشد.";
    public const string VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE = "{0} باید شامل حروف بزرگ باشد.";
    public const string VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE = "{0} باید شامل حروف کوچک باشد.";
    public const string VALIDATION_ERROR_STRING_MUST_HAS_DIGIT = "{0} باید شامل عدد باشد.";
    public const string VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC = "{0} باید شامل کاراکتر خاص باشد.";
    public const string VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR = "{0} باید شامل کاراکتر یکتا باشد.";
    public const string VALIDATION_ERROR_INVLAID_IP_ADDRESS = "آدرس IP نامعتبر است.";

    public const string VALIDATION_ERROR_DATE_LESS_THAN = "{0} باید کوچکتر از {1} باشد.";
    public const string VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL = "{0} باید کوچکتر یا مساوی {1} باشد.";
    public const string VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY = "{0} باید کوچکتر از امروز باشد.";
    public const string VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY = "{0} باید کوچکتر یا مساوی امروز باشد.";
    public const string VALIDATION_ERROR_DATE_GREATER_THAN = "{0} باید بزرگتر از {1} باشد.";
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL = "{0} باید بزرگتر یا مساوی {1} باشد.";
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY = "{0} باید بزرگتر از امروز باشد.";
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY = "{0} باید بزرگتر یا مساوی امروز باشد.";

    public const string NOT_VALID_TO_CHANGE_PASSWORD = "تغییر رمز عبور مجاز نیست.";
    public const string INVALID_DATA = "داده نامعتبر است.";

    #endregion

    #region Entity Fields

    public const string ID = "شناسه";
    public const string BUSINESS_ID = "شناسه تجاری";
    public const string SOFTWAREPART_ID = "شناسه بخش نرم‌افزاری";
    public const string FIRST_NAME = "نام";
    public const string LAST_NAME = "نام خانوادگی";
    public const string DESCRIPTION = "توضیحات";
    public const string IMAGE_URL = "آدرس تصویر";
    public const string BASE_SALARY = "حقوق پایه";
    public const string DATE = "تاریخ";
    public const string ABSORPTION_ALLOWANCE = "حق جذب";
    public const string TRANSPORTATION_ALLOWANCE = "ایاب و ذهاب";
    public const string TAX = "مالیات";
    public const string OVERTIME_CALCULATOR_NAME = "روش محاسبه اضافه‌کاری";
    public const string RECEIVED_SALARY = "حقوق دریافتی";
    public const string EMPLOYEE_SALARY_RECORD = "اطلاعات حقوق این فرد در این ماه";

    #endregion

    #region Logs

    public const string HANDLER_RUN_LOG = "اجرای هندلر {0}";

    #endregion
}
