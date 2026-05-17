namespace OvetimePolicies1.SharedKernel.Translators;

public class TranslatorKeys
{
    #region ValidationMessage

    #region Global

    public const string VALIDATION_ERROR_REQUIRED = nameof(VALIDATION_ERROR_REQUIRED);
    public const string VALIDATION_ERROR_NOT_EXIST = nameof(VALIDATION_ERROR_NOT_EXIST);
    public const string VALIDATION_ERROR_NOT_EXIST_ANY = nameof(VALIDATION_ERROR_NOT_EXIST_ANY);
    public const string VALIDATION_ERROR_DUPLICATE = nameof(VALIDATION_ERROR_DUPLICATE);
    public const string VALIDATION_ERROR_NOT_VALID = nameof(VALIDATION_ERROR_NOT_VALID);
    public const string VALIDATION_ERROR_NOT_EQUAL_TO = nameof(VALIDATION_ERROR_NOT_EQUAL_TO);
    public const string VALIDATION_ERROR_FORMAT = nameof(VALIDATION_ERROR_FORMAT);
    public const string VALIDATION_ERROR_NOT_POSSIBLE_TO_DELETE_USED_ITEM = nameof(VALIDATION_ERROR_NOT_POSSIBLE_TO_DELETE_USED_ITEM);
    public const string VALIDATION_ERROR_CHANGE_STATUS = nameof(VALIDATION_ERROR_CHANGE_STATUS);

    #endregion

    #region Number

    public const string VALIDATION_ERROR_NUMBER_BETWEEN = nameof(VALIDATION_ERROR_NUMBER_BETWEEN);
    public const string VALIDATION_ERROR_NUMBER_LESS_THAN = nameof(VALIDATION_ERROR_NUMBER_LESS_THAN);
    public const string VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN = nameof(VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN);
    public const string VALIDATION_ERROR_NUMBER_GRATER_THAN = nameof(VALIDATION_ERROR_NUMBER_GRATER_THAN);
    public const string VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN = nameof(VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN);
    public const string VALIDATION_ERROR_MUST_BE_NUMERIC = nameof(VALIDATION_ERROR_MUST_BE_NUMERIC);

    #endregion

    #region String

    public const string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = nameof(VALIDATION_ERROR_STRING_LENGTH_BETWEEN);
    public const string VALIDATION_ERROR_STRING_MIN_LENGTH = nameof(VALIDATION_ERROR_STRING_MIN_LENGTH);
    public const string VALIDATION_ERROR_STRING_MAX_LENGTH = nameof(VALIDATION_ERROR_STRING_MAX_LENGTH);
    public const string VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL = nameof(VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL);
    public const string VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE = nameof(VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE);
    public const string VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE = nameof(VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE);
    public const string VALIDATION_ERROR_STRING_MUST_HAS_DIGIT = nameof(VALIDATION_ERROR_STRING_MUST_HAS_DIGIT);
    public const string VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC = nameof(VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC);
    public const string VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR = nameof(VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR);
    public const string VALIDATION_ERROR_INVLAID_IP_ADDRESS = nameof(VALIDATION_ERROR_INVLAID_IP_ADDRESS);

    #endregion

    #region Date

    public const string VALIDATION_ERROR_DATE_LESS_THAN = nameof(VALIDATION_ERROR_DATE_LESS_THAN);
    public const string VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL = nameof(VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL);
    public const string VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY = nameof(VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY);
    public const string VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY = nameof(VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY);
    public const string VALIDATION_ERROR_DATE_GREATER_THAN = nameof(VALIDATION_ERROR_DATE_GREATER_THAN);
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL);
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY);
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY);

    #endregion

    #region Password

    public const string NOT_VALID_TO_CHANGE_PASSWORD = nameof(NOT_VALID_TO_CHANGE_PASSWORD);
    public const string INVALID_DATA = nameof(INVALID_DATA);

    #endregion

    #endregion

    #region Entity Fields

    public const string ID = nameof(ID);
    public const string BUSINESS_ID = nameof(BUSINESS_ID);
    public const string SOFTWAREPART_ID = nameof(SOFTWAREPART_ID);
    public const string FIRST_NAME = nameof(FIRST_NAME);
    public const string LAST_NAME = nameof(LAST_NAME);
    public const string DESCRIPTION = nameof(DESCRIPTION);
    public const string IMAGE_URL = nameof(IMAGE_URL);
    public const string BASIC_SALARY = nameof(BASIC_SALARY);
    public const string DATE = nameof(DATE);
    public const string ALLOWANCE = nameof(ALLOWANCE);
    public const string TRANSPORTATION = nameof(TRANSPORTATION);
    public const string TAX = nameof(TAX);
    public const string OVERTIME_CALCULATOR_NAME = nameof(OVERTIME_CALCULATOR_NAME);
    public const string RECEIVED_SALARY = nameof(RECEIVED_SALARY);
    public const string EMPLOYEE_SALARY_RECORD = nameof(EMPLOYEE_SALARY_RECORD);

    #endregion

    #region Logs

    public const string HANDLER_RUN_LOG = nameof(HANDLER_RUN_LOG);

    #endregion

    #region ApiAndAuth

    public const string API_ERROR_REQUEST_BODY_REQUIRED = nameof(API_ERROR_REQUEST_BODY_REQUIRED);

    public const string AUTH_USERNAME_ALREADY_EXISTS = nameof(AUTH_USERNAME_ALREADY_EXISTS);
    public const string AUTH_REGISTER_SUCCESS = nameof(AUTH_REGISTER_SUCCESS);
    public const string AUTH_INVALID_CREDENTIALS = nameof(AUTH_INVALID_CREDENTIALS);
    public const string AUTH_INVALID_REFRESH_TOKEN = nameof(AUTH_INVALID_REFRESH_TOKEN);
    public const string AUTH_ALREADY_LOGGED_OUT = nameof(AUTH_ALREADY_LOGGED_OUT);
    public const string AUTH_LOGGED_OUT = nameof(AUTH_LOGGED_OUT);

    #endregion
}
