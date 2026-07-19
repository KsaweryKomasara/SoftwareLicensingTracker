namespace EngineeringSoftwareLicensingTracker.Common.Result.Result
{
    public class Result
    {
        public bool IsSuccess { get; }
        public ResultCode Code { get; }

        private Result(bool isSuccess, ResultCode code) { 
            this.IsSuccess = isSuccess;
            this.Code = code;
        }

        public static Result Succes() => new Result(true, ResultCode.SUCCES);
        public static Result Failure(ResultCode code) => new Result(false, code);
    }
}
